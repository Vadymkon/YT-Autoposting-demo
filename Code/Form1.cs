using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using BrightIdeasSoftware;
using System.Diagnostics;
using Microsoft.CSharp.RuntimeBinder;
using System.Configuration;
using YLoader.Properties;
/*
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;
using Google.GData.Client;
using System.Diagnostics;
*/
namespace YLoader
{
    public partial class Form1 : Form
    {
        String active_path = ""; 
        public YTStaff yt;
        public Form1()
        {
            InitializeComponent();
            yt_Button2.Click += new System.EventHandler(yt_Button1_Click); //copy action
            
            //set active path
            active_path = Settings.Default["active_path"].ToString(); //
            if (active_path == "")
                active_path = Settings.Default["paths"].ToString().Split('|').ToList().Last(); //
            if (active_path == "")
                take_path();

            update_dropdownlist();
            
            CEO_settings(); //settings the table of CEO-data
            egoldsToggleSwitch1.Checked = Convert.ToBoolean(Settings.Default["open_form2"]); // check parametrs

            // oauth2.0
            yt = new YTStaff();


            //def description update
            if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + @"\def_descr.txt")) 
            {
            String def_descr = "\r\n";
            File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + @"\def_descr.txt").ToList().ForEach(line => def_descr += $"{line}\r\n");
            Settings.Default["def_descr"] = def_descr;
            Settings.Default.Save();
            }

            //MakeGraphik();
        }

        async void button1_Click(object sender, EventArgs e) //TEST-Button
        {
            //UploadVideo(@"C:\Users\vadymkon\Desktop\test.mp4","test","test Description");
            //RunSomethink(); //upload test video
            /*yt.getListOfMyVideos();
            yt.UpdateVideo(new VideoFile("2",@"C:\Users\vadymkon\Desktop"));*/
            // yt.ThumbnailSetResponse(new VideoFile("2", @"C:\Users\vadymkon\Desktop"));
            //yt.UpdateVideo(new VideoFile("obijmy", @"D:\vadymkon\youtube\НЕКАНОН\Готовый материал\CEO"));
            string message = "1) Click on 'G'-button on top-right corner" + "\r\n" +
                             "\tfor login in your account with channel." + "\r\n" +
                             "\t(if you have some problems contact with me: " + "\r\n" +
                             "\tvadymkonbusiness@gmail.com)" + "\r\n" + 
                             "\r\n" +

                            "2) Upload all videos you need to your " + "\r\n" +
                            "\tYT-channel by yourself without any SEO or dates." + "\r\n" + 
                            "\tJust send it on YT as they are (draft)." + "\r\n" +
                            "\tOther made this program." + "\r\n" + 
                            "\r\n" +
                            
                            "3) Press 'Generate schedule' for new schedule." + "\r\n" +
                            "Then press BIG GREEN BUTTON in center" + "\r\n" + 
                            "\r\n" +

                            "Then just: write SEO for each file in right side." + "\r\n" +
                            "And press 'Realize this schedule on 2d screen. " + "\r\n" +
                            "Your videos will be on YouTube with their SEO." + "\r\n" +
                            "\r\n" +
                            "Next, you can change dates of publishing as you like on 2d screen. " + "\r\n" + 
                            "Or re'Generate schedule' and change all video dates by 1 click." + "\r\n" 
                            ;

            MessageBox.Show(message, "How to use:", MessageBoxButtons.OK ,MessageBoxIcon.Information);
        }
        
        void button2_Click(object sender, EventArgs e) //save template of mails-sending
        {
            emailMessageBox(); // for more functions and full version contact with vadymkonbusiness@gmail.com
        }
        
        void yt_Button1_Click(object sender, EventArgs e) //main big button
        {
            if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + @"\GR_history\_graphik.txt")) MakeGraphik();
            new Form2(this).Show();
        }
        
        private void yt_Button9_Click(object sender, EventArgs e) //refresh OAuth2.0
        {
            MessageBox.Show("Now several sites are going to open. \r\nPlease login in your chosen account \r\nfor managing video several times. \r\n\r\n(if you will login into different \r\naccounts - result of working is your deal :) )","ATTENTION!");
            yt.Refresh();
            yt = new YTStaff();
        }

        async void yt_Button5_Click(object sender, EventArgs e) //Mailing
        {
            emailMessageBox(); // for more functions and full version contact with vadymkonbusiness@gmail.com
        }

        async void yt_Button7_Click(object sender, EventArgs e) //MakeGraphik
        {
            await Task.Run(() => {
                MakeGraphik();
            }); 
        }

        void egoldsToggleSwitch1_CheckedChanged(object sender) //auto open form2
        {
            Settings.Default["open_form2"] = egoldsToggleSwitch1.Checked;
            Settings.Default.Save();
        } 

        void yt_Button8_Click(object sender, EventArgs e) //add source-folder
        {
            take_path();
            update_dropdownlist();
        } 

        void button3_Click(object sender, EventArgs e) //reset program settings
        {
            Settings.Default.Reset();
            MessageBox.Show("Please Reload Program");
            Close();
        } 

        void cmbStyle_SelectedIndexChanged(object sender, EventArgs e) //change active_path
        {
            active_path = cmbStyle.Items[cmbStyle.SelectedIndex].ToString();
            Settings.Default["active_path"] = active_path;
            Settings.Default.Save();
            Console.WriteLine(active_path);
            label2.Visible = false; linkLabel1.Visible = false;
            CEO_settings();
        }

        void yt_Button3_Click(object sender, EventArgs e) //shorts-GR
        {
            emailMessageBox(); // for more functions and full version contact with vadymkonbusiness@gmail.com

        } 

        void emailMessageBox()
        {
            DialogResult result = MessageBox.Show("For more functions or full version\r\nContact with vadymkonbusiness@gmail.com", "Copy email to clipboard?", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Clipboard.Clear();
                Clipboard.SetText("vadymkonbusiness@gmail.com");
            }
        }

        void Form1_Shown(object sender, EventArgs e) //auto open form2
        {
            if (egoldsToggleSwitch1.Checked) new Form2(this).Show(); // CheckBox action
        }

        void yt_Button6_Click(object sender, EventArgs e) //open custom GR file
        {
            emailMessageBox(); // for more functions and full version contact with vadymkonbusiness@gmail.com
        }

        void yt_Button10_Click(object sender, EventArgs e) //Thumbnails UPLOAD
        {
            var a = getVideoList().Where(x => x.Id != "").ToList(); //get Id-in videos
            egoldsProgressBar1.ValueMaximum = a.Count; //progressbar settings
            
            a.ForEach(x => { yt.ThumbnailSetResponse(x); //thumbnails uploading
                ++egoldsProgressBar1.Value;
            });

        }

        void yt_Button4_Click(object sender, EventArgs e) //move next 1 month videos in near folder and open it
        {
            emailMessageBox(); // for more functions and full version contact with vadymkonbusiness@gmail.com
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveIdsToCEO();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "/GR_history");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.active_path);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //def description update
            String path = Path.GetDirectoryName(Application.ExecutablePath) + @"\def_descr.txt";
            if (!File.Exists(path))
                File.WriteAllText(path,"");
         
            String def_descr = "\r\n";
            File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + @"\def_descr.txt").ToList().ForEach(line => def_descr += $"{line}\r\n");
            Settings.Default["def_descr"] = def_descr;
            Settings.Default.Save();
            Process.Start(path);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            emailMessageBox(); // for more functions and full version contact with vadymkonbusiness@gmail.com
        }
        private void button10_Click(object sender, EventArgs e)
        {
            emailMessageBox(); // for more functions and full version contact with vadymkonbusiness@gmail.com
        }

        private void button9_Click(object sender, EventArgs e)
        {
            emailMessageBox(); // for more functions and full version contact with vadymkonbusiness@gmail.com
        }


    }


    static class MyExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static DateTime toDateTime(this String line)
        {
            List<int> datePartList = line.Trim().Split('.').ToList().Select(y => Convert.ToInt32(y)).ToList();
            DateTime PublishedDate = new DateTime(datePartList[2], datePartList[1], datePartList[0]);
            return PublishedDate;
        }

        public static String formatOff(this String line)
        {
            List<String> Symbols = new List<string> { ".", "_" }; //to space
            Symbols.ForEach(x => { line = line.Replace(x, " "); });
            List<String> SymbolsOff = new List<string> { "(", ")" }; //symbols which replacing to NOTHING
            SymbolsOff.ForEach(x => { line = line.Replace(x, ""); });
            return line.ToLower().Trim();
        }
    }
}