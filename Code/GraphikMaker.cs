using System;
using System.Collections.Generic;
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
        //Graphik Staff
        internal void MakeGraphik(List<String> videosUpload = null, bool addwrite = false)
        {
            List<Playlist> playlists = new List<Playlist>();
            int countVideos;
            Graphik graphik;


            String path = Settings.Default["active_path"].ToString();

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles(); // get info about files in directory

            List<String> videoss = new List<string>(); //list with all videos (in directory)

            if (videosUpload == null)
                directoryInfo.GetFiles().ToList().Where(x => x.Name.Contains(".mp4")).OrderBy(x => x.LastWriteTime).ToList().ForEach(x => videoss.Add(x.Name)); // sort by date and add to list
            else videoss = videosUpload;
            videoss = videoss.GetRange(0, videoss.Count > 50 ? 50 : videoss.Count);
            
            Gr1(videoss);
            Gr2();
            //make playlists
            void Gr1(List <String> videos)
            {

                // PRINT VIDEOS_names TO TEXTBOX videos.ForEach(x=> textBox1.Text += $"{x}\r\n");
                //List<Playlist> playlists = new List<Playlist>();

                //making playlists
                videos.ForEach(x =>
                {
                    String prefix = x.Split('_')[0].Split(' ')[0].Split('.')[0]; //get prefix name of video
                    int v = playlists.FindIndex(y => y.NameOfPlaylist == prefix); //if it already exists - that his index
                    if (v != -1) playlists[v].push_back(x); // if it's not -1, push this name of video inside
                    else playlists.Add(new Playlist(x)); //make new playlist in our list
                });
                countVideos = videos.Count;
                //textBox1.Text = countVideos.ToString();
                //on this step we have many playlists with ONLY one video.
                //That's not cool
                // 2d STEP OF FILTERING
                videos.Clear(); // re-use
                playlists.Where(x => x.Count() == 1).ToList().ForEach(x => { videos.Add(x.get_elem()); playlists.Remove(x); }); //find singletones

                //find prefix'es 
                //if not starting on some of already finded prefixes
                //get first 2 letters
                //if good - get first 3 letters
                // if good - replace, no? save 2 letters

                // finding prefixes
                List<String> prefixes = new List<string>();
                String prefix_buffer = "";
                videos.ForEach(x =>
                {
                    if (prefixes.Where(y => x.StartsWith(y)).ToList().Count == 0) //if there no prefixes familiar to elem x
                    {
                        int lettersInPrefix = 2; //startLength
                        bool isPrefix = false; // checker for "while"
                        while (videos.Where(y => y.StartsWith(x.Substring(0, lettersInPrefix))).ToList().Count > 1) //if there list (where 2 or more names) with this prefix
                        {
                            isPrefix = true; // checked
                            ++lettersInPrefix; //try again but more letters
                        };
                        if (isPrefix) prefixes.Add(x.Substring(0, lettersInPrefix - 1)); //add prefix
                    }
                });

                //filter videos with found prefixes
                prefixes.ForEach(x =>
                {
                    videos.Where(y => y.StartsWith(x)).ToList()
                    .ForEach(y =>
                    {
                        int v = playlists.FindIndex(z => z.NameOfPlaylist == x); //if it already exists - that his index
                        if (v != -1) playlists[v].push_back(y); // if it's not -1, push this name of video inside
                        else playlists.Add(new Playlist(y, x)); //make new playlist in our list
                        videos.Remove(y);
                    });
                });

                //STEP 3 - get all other videos to one somnitelniy playlist
                if (videos.Count != 0)
                playlists.Add(new Playlist(videos[0], "somn")); if (videos.Count != 0) videos.RemoveAt(0);
                videos.ForEach(x => playlists.Last().push_back(x));

                //print
                /*playlists.ForEach(x => textBox1.Text += x.print());
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\1.txt",textBox1.Text);
                textBox1.Text = playlists.Count.ToString();*/

                //DEBUG: swap buffer zone
                /*
                 */


            }
            //make graphik
            void Gr2()
            {
                graphik = new Graphik(countVideos); //make list for graphik
                Playlist_s pl_S = new Playlist_s(playlists);
                pl_S.random_sort();

                int i = 0;
                while (pl_S.playlists.Count > 0) //while videos inside are not removed
                {
                    List<int> indexes;
                    bool size_out = false; //if graphik range is rangeout
                    int whiletry = 0; //finding free places
                    if (size_out) //just set it on free places 
                    {
                        // SetToFreePlaces Algorithm
                        whiletry = 0;
                        //here is some pl[i] with videos
                        while (pl_S.playlists[i].Count() > 0) //while videos are in playlist
                        {
                            int state = -1;
                            String elem = pl_S.playlists[i].get_elem();
                            while (state == -1)
                            {
                                state = graphik.putElementOnIndex(whiletry, elem); //try to put and get state
                                whiletry++; //try to put it in graphik
                                if (state == -2) continue; //message that range is out
                            }
                        }
                        if (pl_S.playlists[i].Count() == 0) pl_S.playlists.RemoveAt(i);
                    }
                    else
                    {
                        if (pl_S.playlists[i].Count() == 0) pl_S.playlists.RemoveAt(i);

                        if (pl_S.playlists.Count > i)
                            if (pl_S.playlists[i].type.Length != 0)
                            {
                                if (pl_S.playlists[i].type == "M") //if music
                                    indexes = indexes_m(pl_S.playlists[i].Count()); //get step-indexes
                                else //if partable
                                    indexes = indexes_p(pl_S.playlists[i].Count()); //get step-indexes

                                // Music/Partible algorithm
                                indexes.ForEach(index =>
                                {
                                    String elem = pl_S.playlists[i].get_elem(); //get element for this index
                                    int state = -1;
                                    while (state == -1)
                                    {
                                        state = graphik.putElementOnIndex(index + whiletry, elem); //try to put and get state
                                        whiletry++; //try to put it in graphik
                                        if (state == -2) size_out = true; //message that range is out
                                    }
                                });
                            }
                            else
                            {
                                // P2P algorithm 
                                //here we 2 playlists i & i+1.
                                bool isOverF = false, isOverS = false;
                                int step = 0;
                                while (!isOverF && !isOverS && !size_out) //if both playlists have videos and range is ok
                                {
                                    step++;
                                    if (step > 11) //if playlist is too long - bucnut it
                                    {
                                        isOverF = true;
                                        isOverS = true;
                                        pl_S.bucnut_na(2, i);
                                        continue;
                                    }
                                    Tuple<int, int> pair = indexes_p2p(step); //get state for step

                                    //do for 1st playlist
                                    for (int j = 0; j < pair.Item1; j++)
                                        if (pl_S.playlists.Count > i)
                                            if (pl_S.playlists[i].Count() > 0) // check fullness playlist
                                            {
                                                if (!size_out) // check rangeout of graphik
                                                {
                                                    //tryness to put this element
                                                    String elem = pl_S.playlists[i].get_elem();
                                                    int state = -1;
                                                    while (state == -1)
                                                    {
                                                        state = graphik.putElementOnIndex(whiletry, elem); //try to put and get state
                                                        whiletry++; //try to put it in graphik
                                                        if (state == -2) size_out = true; //message that range is out
                                                    }
                                                }
                                            }
                                            else { isOverF = true; if (pl_S.playlists[i].Count() == 0) pl_S.playlists.RemoveAt(i); }//if playlist is over

                                    //do for 2d playlist
                                    for (int j = 0; j < pair.Item2; j++)
                                        if (pl_S.playlists.Count > i + 1)
                                            if (pl_S.playlists[i + 1].Count() > 0) // check fullness playlist
                                            {
                                                if (!size_out) // check rangeout of graphik
                                                {
                                                    //tryness to put this element
                                                    String elem = pl_S.playlists[i + 1].get_elem();
                                                    int state = -1;
                                                    while (state == -1)
                                                    {
                                                        state = graphik.putElementOnIndex(whiletry, elem); //try to put and get state
                                                        whiletry++; //try to put it in graphik
                                                        if (state == -2) size_out = true; //message that range is out
                                                    }
                                                }
                                            }
                                            else { isOverS = true; if (pl_S.playlists[i + 1].Count() == 0) pl_S.playlists.RemoveAt(i + 1); }//if playlist is over

                                }
                            }
                    }
                }

               
            }

            
            //data
            String pathCEO = Path.GetDirectoryName(Application.ExecutablePath) + "/GR_history";
            String saveGRdata = graphik.print_ForEvery3days(new DateTime(2024, 6, 1));
            //saving
            Directory.CreateDirectory(pathCEO);
            if (addwrite)
            {
                String[] file = File.ReadAllLines(pathCEO + "/_graphik.txt"); // save&print
                saveGRdata = "";
                file.ToList().ForEach(line => saveGRdata += $"{line}\r\n"); 
                saveGRdata += graphik.print_ForEvery3days(file.Last(x => x.Trim() != "").Split(':')[0].Trim().toDateTime().AddDays(3)); //get startdate from file
            }

            File.WriteAllText(pathCEO + "/_graphik.txt", saveGRdata); // save&print
            File.WriteAllText(pathCEO + $"/GR_{Directory.GetFiles(pathCEO).Length}.txt", saveGRdata); // save&print

        }

        internal void SaveGRtoFile(List<VideoFile> videoFiles, String startDate = "01.06.2024")
        {

            //data
            String pathCEO = Path.GetDirectoryName(Application.ExecutablePath) + "/GR_history";
            String saveGRdata = new Graphik(videoFiles).print_ForEvery3days(startDate.toDateTime());
            Directory.CreateDirectory(pathCEO);

            //saving
            File.WriteAllText(pathCEO + "/_graphik.txt", saveGRdata); // save&print
            File.WriteAllText(pathCEO + $"/GR_{Directory.GetFiles(pathCEO).Length}.txt", saveGRdata); // save&print

        }
        Tuple<int, int> indexes_p2p(int step)
        {
            switch (step % 6)
            {
                case 0:
                    return Tuple.Create(3, 1);
                    break;
                case 1:
                    return Tuple.Create(2, 2);
                    break;
                case 2:
                    return Tuple.Create(2, 3);
                    break;
                case 3:
                    return Tuple.Create(1, 3);
                    break;
                case 4:
                    return Tuple.Create(2, 2);
                    break;
                case 5:
                    return Tuple.Create(3, 2);
                    break;
            };
            return Tuple.Create(1, 1);
        }
        List<int> indexes_m(int size)
        {
            List<int> indexes = new List<int>();
            int previous_plus = 0;

            for (int i = 1; i < size + 1; i++)
            {
                switch (i % 5)
                {
                    case 0:
                        previous_plus += 1;
                        break;
                    case 1:
                        previous_plus += 1;
                        break;
                    case 2:
                        previous_plus += 2;
                        break;
                    case 3:
                        previous_plus += 1;
                        break;
                    case 4:
                        previous_plus += 3;
                        break;
                };
                indexes.Add(previous_plus);
            }
            indexes.Select(x => x -= 1);
            return indexes;
        }
        List<int> indexes_p(int size)
        {
            List<int> indexes = new List<int>();
            int previous_plus = 0;

            for (int i = 1; i < size + 1; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        previous_plus += 1;
                        break;
                    case 1:
                        previous_plus += 3;
                        break;
                    case 2:
                        previous_plus += 2;
                        break;
                    case 3:
                        previous_plus += 1;
                        break;
                };
                indexes.Add(previous_plus);
            }
            indexes.Select(x => x -= 1);
            return indexes;
        }
    }
}
