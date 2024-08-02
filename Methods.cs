using BrightIdeasSoftware;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YLoader.Properties;

namespace YLoader
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Rewrite ALL CEO to empty template.
        /// </summary>
        /// <param name="path">pathWhereVideo</param>
        void makeCEO_forAllVideos(String path = "")
        {
            // for all videos make CEO
            if (path == "") path = Settings.Default["active_path"].ToString(); //default way
            String pathCEO = path + @"\CEO";
            Directory.CreateDirectory(pathCEO);
            Directory.GetFiles(path).ToList().Where(x => x.EndsWith(".mp4")).ToList() //for all videos
                .ForEach(x =>
                {
                    new VideoFile(x.Replace(path + @"\", "").Replace(".mp4", "")).saveCEOInfo(pathCEO); //save
                });
        }

        void makeCEO_forListVideos(List<VideoFile> videos, String path = "")
        {
            // for all videos make CEO
            if (path == "") path = Settings.Default["active_path"].ToString(); //default way
            String pathCEO = path + @"\CEO";
            Directory.CreateDirectory(pathCEO);
            videos.ForEach(x => x.saveCEOInfo(pathCEO));
        }

        List<VideoFile> getVideoList(String path = "")
        {
            List<VideoFile> videos = new List<VideoFile>();
            // for all videos make CEO
            if (path == "") path = Settings.Default["active_path"].ToString(); //default way
            String pathCEO = path + @"\CEO";
            Directory.CreateDirectory(pathCEO);
            Directory.GetFiles(path).ToList().Where(x => x.EndsWith(".mp4")).ToList() //for all videos
                .ForEach(x =>
                {
                    VideoFile a = new VideoFile(x.Replace(path + @"\", "").Replace(".mp4", "")); //загрузка правильного FileName
                    a.putCEOInfo(pathCEO); //getCEOinfo
                    videos.Add(a);
                });
            return videos;
        }

        List<VideoFile> getVideoListFromSEO(String path = "")
        {
            List<VideoFile> videos = new List<VideoFile>();
            // for all videos make CEO
            if (path == "") path = Settings.Default["active_path"].ToString(); //default way
            String pathCEO = path + @"\CEO";
            Directory.CreateDirectory(pathCEO);
            Directory.GetFiles(pathCEO).ToList().Where(x => x.EndsWith(".txt")).ToList() //for all videos
                .ForEach(x =>
                {
                    VideoFile a = new VideoFile(x.Replace(pathCEO + @"\", "").Replace(".txt", "")); //загрузка правильного FileName
                    a.putCEOInfo(pathCEO); //getCEOinfo
                    videos.Add(a);
                });
            return videos;
        }

        async void saveIdsToCEO()
        {
            var a = new YTStaff();
            await a.getListOfMyVideos(); //videos from youtube

            var b = getVideoList(); // vFiles

            b.ForEach(x =>
            {
                var videosComparing = a.own_videos.ToList().Where(y => y.Snippet.Title == (x.Title != "" ? x.Title : "n)sk2") 
                || y.Snippet.Title.formatOff() == (x.FileName.formatOff())).ToList();
                if (videosComparing.Count > 0) x.Id = videosComparing[0].Snippet.ResourceId.VideoId;
            }); //finding Id for this

            b.ForEach(x => x.saveCEOInfo(Settings.Default["active_path"].ToString() + @"\CEO"));
        }

        


        void CEO_settings()
        {
            //table settings
            List<VideoFile> videos = getVideoList(); //list with videos
            //table
            objectListView1.GetColumn(0).AspectToStringConverter = delegate (object x)
            { //for all filenames
                String file = (String)x; //example of string
                return file + ".txt"; //make txt
            };
            objectListView1.FormatCell += olv1_FormatCell; //make green cells
            objectListView1.CellClick += olv1_Click; //make opening files
            objectListView1.SetObjects(videos.Where(x => x.IsHaveCEOfile)); //start data
            //for Videos Without CEO-files (right-bottom corner labels)
            List<VideoFile> videosWithoutCEO = videos.Where(x => !x.IsHaveCEOfile).ToList();
            if (videosWithoutCEO.Count > 0) //if there are
            {
                label2.Visible = true;
                label2.Text = $"{videosWithoutCEO.Count} videos without SEO at all."; //right-bottom corner message
                linkLabel1.Visible = true;
                linkLabel1.Click += new System.EventHandler((a, e) =>
                {
                    videosWithoutCEO.ForEach(x => x.saveCEOInfo(active_path));
                    table1Reload(videos);
                    label2.Text = "";
                    linkLabel1.Visible = false;
                    new Graphik(Path.GetDirectoryName(Application.ExecutablePath) + @"\GR_history\_graphik.txt")
                    .writeDatesToCEO(Settings.Default["active_path"].ToString() + @"\CEO",
                        Path.GetDirectoryName(Application.ExecutablePath) + @"\GR_history\_graphik.txt");
                    saveIdsToCEO();
                }); //link-action
            }
        }
        /// <summary>
        /// Make green cells if Title is exists in VideoFile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void olv1_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == objectListView1.GetColumn(0).Index)
            {
                VideoFile video = (VideoFile)e.Model; //example
                if (video.Title != "") e.SubItem.BackColor = Color.LightGreen;
            }
        }
        /// <summary>
        /// Open .txt file with CEO of video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void olv1_Click(object sender, CellClickEventArgs e)
        {
            if (e.ColumnIndex == objectListView1.GetColumn(0).Index)
            {
                VideoFile video = (VideoFile)e.Model; //get example of fule
                if (video != null)
                {
                    if (File.Exists(active_path + "\\CEO\\" + video.FileName + ".txt"))
                        Process.Start(active_path + "\\CEO\\" + video.FileName + ".txt"); //start process
                    if (Process.GetProcessesByName("notepad").Length == 2) Process.GetProcessesByName("notepad").ToList().First().Kill(); //this custom-table have problem with double action on ONLY one click. This is solution - kill one copy of file
                    table1ReloadTimer(); //reload table-list
                }
            }
        }

        /// <summary>
        /// Async reload
        /// </summary>
        async void table1ReloadTimer()
        {
            int scrollpos = objectListView1.LowLevelScrollPosition.Y; //scrollsave

            var process = Process.GetProcessesByName("notepad"); //target
            while (process.Any(x => !x.HasExited)) await Task.Delay(2000).ConfigureAwait(false); //is notepad still open

            Console.WriteLine("TABLE IS RELOADED ASYNC."); //logs
            table1Reload(getVideoList()); //reset elements
            Invoke(new Action(() => //bcs thread-error
            {
                objectListView1.LowLevelScroll(0, scrollpos * 8); //scrollsave
            }));
        }

        void table1Reload(List<VideoFile> videos)
        {
            objectListView1.SetObjects(videos.Where(x => x.IsHaveCEOfile)); //reset all elements
        }

        internal void UpdateVideos(List<VideoFile> vf, bool Shorts = false)
        {
            Invoke((Action)(
               () =>
               {
                   vf = vf.Where(x => x.Id != "").ToList();
                   label3.Visible = true;
                   egoldsProgressBar1.Value = 0;
                   egoldsProgressBar1.ValueMaximum = vf.Count;


                   DateTime dateTimeCURR = new DateTime(), 
                            dateTimeBEF = new DateTime(); //dateTime buffers
                   int againer = 0; //

                   vf.ForEach(x =>
                   {
                       int hours = 13;
                       if (Shorts)
                       {
                           //13 - 16 - 19 (for shorts)
                           dateTimeCURR = x.PublishedDate;
                           if (dateTimeCURR == dateTimeBEF) ++againer;
                           else againer = 0;
                           switch (againer)
                           {
                               case 0:
                                   hours = 13;
                                   break;
                               case 1:
                                   hours = 16;
                                   break;
                               case 2:
                                   hours = 19;
                                   break;
                               default:
                                   hours = 13;
                                   break;
                           }
                       }

                       //stahdart update
                       yt.UpdateVideo(x,hours);
                       ++egoldsProgressBar1.Value;
                       label3.Text = $"Загружено {egoldsProgressBar1.Value}";

                       if (Shorts)
                       dateTimeBEF = dateTimeCURR;
                   });
                   new Form2(this).Show();
               }));

        }


        public void take_path()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Choose directory where videos for upload are.";

                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    Settings.Default["paths"] += "|" + selectedFolder;
                    Settings.Default["active_path"] = selectedFolder;
                    Settings.Default.Save();
                }
            }
        }

        void update_dropdownlist()
        {
            string[] a = Settings.Default["paths"].ToString().Split('|').ToList().Where(x => x.Trim() != "").ToArray(); //range of paths and no empty slots
            cmbStyle.Items.Clear();
            cmbStyle.Items.AddRange(a); //add
            cmbStyle.SelectedIndex = a.ToList().IndexOf(Settings.Default["active_path"].ToString()) != -1 ?
                a.ToList().IndexOf(Settings.Default["active_path"].ToString()) //active path
            : a.Length - 1; //last
        }

        //
    }

    public partial class Form2 : Form
    {
        void table_settings()
        {
            //for DateTime converting in table
            objectListView1.GetColumn(1).AspectToStringConverter = delegate (object x) {
                DateTime date = (DateTime)x;
                return date.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
            };
            objectListView1.FormatCell += olv1_FormatCell;
            objectListView1.FormatRow += olv1_FormatRow;
            objectListView1.ItemActivate += objectListView1_ItemActivate;
            objectListView1.ItemChecked += ObjectListView1_ItemChecked;
            objectListView1.CellRightClick += ObjectListView1_CellRightClick;


            reload_table();
            update_dropdownlist();
        }

        private void ObjectListView1_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (videoFiles_buffer.Count != 0)
            {

                if (e.ColumnIndex == objectListView1.GetColumn(0).Index)
                {
                    VideoFile video = (VideoFile)e.Model; //get example of fule
                    if (video != null)
                    {
                        videoFiles.InsertRange(videoFiles.IndexOf(video) + 1, videoFiles_buffer); //add to this place all range
                        videoFiles_buffer.Clear();

                        using (var a = new Form1())
                        {
                            try
                            {
                                a.SaveGRtoFile(videoFiles, egoldsGoogleTextBox2.Text);
                            }
                            catch
                            {
                                MessageBox.Show("write startdate correctly");
                                return;
                            }
                        }
                        reload_table();
                        yt_Button10_Click(this, e);
                    }
                }
            }
        }
        void olv1_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (!isFormatted) return;

            VideoFile video = (VideoFile)e.Model; //example

            //format already PUBLIC videos
            if (parentForm.yt.own_videos.Where(x => x.Snippet.PublishedAt < DateTime.Now) //all public videos
                .Where(x => x.Snippet.Title.formatOff().Contains(video.Title != "" ? video.Title.formatOff() : "a2f)d") //if Title exists 
                || x.Snippet.Title.formatOff().Contains(video.FileName.formatOff()) || x.Id == video.Id) //which are in our collection
                .ToList().Count != 0) //if there this video 
            {
                e.Item.BackColor = Color.DarkGreen;
                return;
            }
            //format no public videos
            if (video.Id.Trim() == "") e.Item.BackColor = Color.FromArgb(220, 20, 60); //or just only on PC
            else e.Item.BackColor = Color.LightGreen; // but on YouTube (with Id)

        }
        void olv1_FormatCell(object sender, FormatRowEventArgs e)
        {
            if (!isFormatted) return;

            VideoFile video = (VideoFile)e.Model; //example
            List<Color> colorsInFormatRow = new List<Color>(new Color[] { Color.FromArgb(220, 20, 60) });
            //protect FormatRow
            if (colorsInFormatRow.Contains(e.Item.BackColor)) return;

            //format Dates
            if (parentForm.yt.own_videos.Where(x => x.Snippet.PublishedAt == video.PublishedDate) //all videos with same Pdate
                .Where(x => x.Snippet.Title.Contains(video.Title != "" ? video.Title : "a2f)d") //if Title exists 
                || x.Snippet.Title.Contains(video.FileName) || x.Id == video.Id) //which are in our collection
                .ToList().Count == 0) //if there this video 
            {
                e.Item.GetSubItem(1).BackColor = Color.FromArgb(220, 20, 60); //light red
            }
            else
                e.Item.GetSubItem(1).BackColor = Color.LightGreen; //if date correct


            //format Titles
            if (parentForm.yt.own_videos.Where(x => x.Id == video.Id) //all videos with same Pdate
                .Where(x => x.Snippet.Title.formatOff().Contains(video.Title != "" ? video.Title.formatOff() : "a2f)d")) //if Title exists 
                .ToList().Count == 0) //if there this video 
            {
                e.Item.BackColor = Color.Orange; //light red
            }
            else
                e.Item.BackColor = Color.LightGreen; //if title correct

        }

        /*
       //table staff
       void olv1_FormatCell(object sender, FormatCellEventArgs e)
       {
           if (e.ColumnIndex == objectListView1.GetColumn(0).Index)
           {
               VideoFile video = (VideoFile)e.Model; //example
               if (video.Title != "") e.SubItem.BackColor = Color.LightGreen;
           }
       }
*/
        private void objectListView1_ItemActivate(object sender, EventArgs e)
        {
            foreach (OLVListItem olvi in objectListView1.SelectedItems)
            {
                olvi.Checked = !olvi.Checked;
                Console.WriteLine(olvi.RowObject.ToString());
            }
        }
        private void ObjectListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Console.WriteLine(e.Item.Checked + e.Item.Text);
            if (e.Item.Checked)
            {
                videoFiles_buffer.Add(videoFiles.First(x => x.FileName == e.Item.Text || x.Title == e.Item.Text)); //in buffer add
                videoFiles.Remove(videoFiles.First(x => x.FileName == e.Item.Text || x.Title == e.Item.Text)); //remove from gen list
            }
            else //false
            {
                videoFiles.Add(videoFiles_buffer.First(x => x.FileName == e.Item.Text || x.Title == e.Item.Text)); //add to gen list
                videoFiles_buffer.Remove(videoFiles_buffer.First(x => x.FileName == e.Item.Text || x.Title == e.Item.Text)); //remove in buffer 
            }

        }

        async void reload_table()
        {
            //   Invoke((Action)(() => { 
            //   }));
            //update own_videos
            await parentForm.yt.getListOfMyVideos();
            //get Graphik infoInvoke
            Graphik a;
            if (CustomGR.Trim() != "")
                a = new Graphik(CustomGR); //in case where we gonna watch custom GR
            else
            {

                if (Shorts == false)
                    a = new Graphik(Path.GetDirectoryName(Application.ExecutablePath) + @"\GR_history\_graphik.txt");
                else
                {
                    a = new Graphik(Path.GetDirectoryName(Application.ExecutablePath) + @"\GR_history\_graphik_SH.txt");
                }
            }


            videoFiles = a.GetVideoFiles();
            objectListView1.SetObjects(videoFiles); //put VideoFiles-info to table

            egoldsGoogleTextBox2.Text = a.queueDT[0].ToString("dd.MM.yyyy", CultureInfo.InvariantCulture); //change textbox // that's comforable to set it here

        }



        void update_dropdownlist()
        {
            string[] a = Settings.Default["paths"].ToString().Split('|').ToList().Where(x => x.Trim() != "").ToArray(); //range of paths and no empty slots
            cmbStyle.Items.Clear();
            cmbStyle.Items.AddRange(a); //add
            cmbStyle.SelectedIndex = a.ToList().IndexOf(Settings.Default["active_path"].ToString()) != -1 ?
                a.ToList().IndexOf(Settings.Default["active_path"].ToString()) //active path
            : a.Length - 1; //last
        }


        private void egoldsToggleSwitch1_CheckedChanged(object sender)
        {
            isFormatted = egoldsToggleSwitch1.Checked;
            objectListView1.BuildList();
        }

        private void egoldsToggleSwitch2_CheckedChanged(object sender)
        {
            objectListView1.GetColumn(0).AspectName = egoldsToggleSwitch2.Checked ? "Title" : "FileName";
            objectListView1.BuildList();
        }
    }
}
