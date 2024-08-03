using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YLoader.Properties;

namespace YLoader
{
    class Graphik
    {
        public List<String> queue = new List<string>();
        public List<DateTime> queueDT = new List<DateTime>();
        DateTime startDate;
        public Graphik(int value)
        {
            //making list of Graphik
            for (int i = 0; i<value; i++) queue.Add("");
        }

        /// <summary>
        /// Make graphik from file
        /// </summary>
        /// <param name="path"></param>
        public Graphik(String path)
        {
            //get file
            File.ReadAllLines(path).ToList().ForEach(x => { //for each line
                List<String> arr = x.Split(':').ToList();  //split
                if (arr.Count > 1) //if it is line with data
                {
                    queueDT.Add(arr[0].Trim().toDateTime()); //add date 
                    if (arr[1].EndsWith(".")) arr[1] = arr[1].Substring(0, arr[1].Length - 1); // '.' in the finish of string
                    queue.Add(arr[1].Trim()); //add name of video
                }
            });
        }

        public Graphik(List <VideoFile> videoFiles)
        {
            videoFiles.ForEach(x => queue.Add(x.FileName));
            videoFiles.ForEach(x => queueDT.Add(x.PublishedDate));
        }

        public List<VideoFile> GetVideoFiles()
        {
            List<VideoFile> videoFiles = new List<VideoFile>();
            queue.ForEach(x =>
            {
                if (File.Exists(Settings.Default["active_path"].ToString() + @"\CEO\"+x+".txt"))
                    videoFiles.Add(new VideoFile(x.Trim(), Settings.Default["active_path"].ToString() + @"\CEO"));
                else
                    videoFiles.Add(new VideoFile(x.Trim(), queueDT[queue.IndexOf(x)]));
            });
            return videoFiles;
        }

        public void insert(List<String> lines, String inDate)
        {
            queue.InsertRange(queueDT.IndexOf(FindClosestDate(queueDT, inDate.toDateTime())), lines);
            for (int i = 0; i < lines.Count; i++) queueDT.Add(queueDT.Last().AddDays(3));
        }
        
        public List <VideoFile> getInsertedVideoFiles ()
        {
            List<VideoFile> videos = GetVideoFiles();
            //corrective dates
            videos.ForEach(x => { 
            if (queue.Contains(x.FileName) || queue.Contains(x.Title))
                {
                    int index = queue.IndexOf(x.FileName);
                    if (index == -1)
                        index = queue.IndexOf(x.Title); //safety
                    x.PublishedDate = queueDT[index];
                }
            });

            return videos;
        }

        static DateTime FindClosestDate(List<DateTime> dateList, DateTime targetDate)
        {
            DateTime closestDate = dateList.OrderBy(d => Math.Abs((d - targetDate).Ticks)).First();
            return closestDate;
        }
    

    public void newStartDate(DateTime NewstartDate, int mode = 0)
        {
            startDate = NewstartDate;
            if (mode == 0) for (int i = 0; i < queueDT.Count; i++) queueDT[i] = startDate.AddDays(3 * i); //3days mode qDT
        }

        public int putElementOnIndex(int index, String element)
        {
            if (index >= queue.Count) { queue.Add(element); return -2; } //if jumped out put and say about rangeout
            if (queue[index] != "") return -1; //if it putted by other video
            queue[index] = element; //put element on que
            return 0; 
        }

        public void remove_spaces()
        {
            queue.RemoveAll(x => x == "");
        }

        public String print_ForEvery3days(DateTime startDate)
        {
            remove_spaces();
            String message = "  Graphik made by YT Uploader\r\n\r\n";
            if (queueDT == null || queueDT.Count == 0)
            queue.ForEach(x => message += $"{startDate.AddDays(3*queue.IndexOf(x)).ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)} : {x.Replace("mp4","")}\r\n");
            else 
            queue.ForEach(x => message += $"{queueDT[queue.IndexOf(x)].ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)} : {x.Replace("mp4","")}\r\n");

            return message;
        }

        public String print()
        {
            remove_spaces();
            String message = "  Graphik made by YT Uploader\r\n\r\n";
            queue.ForEach(x => message += $"{queueDT[queue.IndexOf(x)].ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)} : {x.Replace("mp4","")}\r\n");
            return message;
        }

        public void writeDatesToCEO(String pathToCEO, String pathToGraphik)
        {
            List <VideoFile> a = new List<VideoFile>(); //making list for comparing
            //get file
            File.ReadAllLines(pathToGraphik).ToList().ForEach(x => { //for each line
                if (x.Contains(':'))
                {
                    List<String> arr = x.Split(':').ToList(); //split
                    if (arr[1].EndsWith(".")) arr[1] = arr[1].Substring(0, arr[1].Length - 1);
                    a.Add(new VideoFile(arr[1].Trim(), arr[0].Trim().toDateTime())); //add element to list
                }
            });
            List <VideoFile> b = GetVideoFiles(); //original list without dates

            b.ForEach(x => {x.PublishedDate = a.First(y => y.FileName == x.FileName).PublishedDate;});
            b.ForEach(x => x.saveCEOInfo(pathToCEO));

        }

    }
}
