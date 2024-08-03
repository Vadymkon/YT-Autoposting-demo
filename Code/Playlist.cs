using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YLoader
{
    class Playlist
    {
        List<String> ListOfVideos;

        public String NameOfPlaylist = "";
        public String type = ""; //type of playlist : "", "M" , "P", "MP"

        public DateTime date4SHORTS = new DateTime(); // made for shorts

        // constructor
        public Playlist(String element) //get first video name
        {
            ListOfVideos = new List<String>(); //make list avaliable
            push_back(element); //added this element
            NameOfPlaylist = element.Split('_')[0].Split(' ')[0].Split('.')[0]; ; //get name of this playlist
        }
        
        // constructor 2
        public Playlist(String element, String prefix) //get first video name and prefix
        {
            ListOfVideos = new List<String>(); //make list avaliable
            if (element != "") push_back(element); //added this element
            NameOfPlaylist = prefix; //get name of this playlist
        }

        // constructor 3
        public Playlist(String prefix, DateTime dateTime) //get first video name and prefix
        {
            ListOfVideos = new List<String>(); //make list avaliable
            NameOfPlaylist = prefix; //get name of this playlist
            date4SHORTS = dateTime;
            type = "SH";
        }



        public void push_back(String elem) // add new element to the list
        {
            ListOfVideos.Add(elem);
            if (type != "SH") identify_type(elem);
            if (type == "M") sort_music_type();
           // else if (type == "P") sort_p_type();
        }
        public String get_elem()  // return first element and remove it
        {
            String element = ListOfVideos.First();
            ListOfVideos.RemoveAt(0);
            return element;
        }
        void identify_type(string elem)
        {
            if (!type.Contains("P"))
                if (elem.Contains("p2"))
                {
                    type += "P";
                }
            if (!type.Contains("M"))
            {
                List<String> music_staff = new List<string> { "instr", "acapell", "speed", "slow" };
                music_staff.ForEach(x => { if (elem.Contains(x)) type += "M"; }); // if elem(name of video) has something about music - change type
            }

        }
        public int Count() {return ListOfVideos.Count;}
        public String print() // print information about playlist
        {
            String message = $"---{NameOfPlaylist}--\r\n{ListOfVideos.Count} + ''{type}''\r\n" + " { \r\n";
            ListOfVideos.ToList().ForEach(x => message += $"{x}\r\n");
            message += " } \r\n\r\n";
            return message;
        }

        void sort_music_type()
        {
            List<String> music_staff = new List<string> { "speed", "prikol", "slow" , "acapell", "rus", "instr", "minus", "demo"}; //que of publicitian
            music_staff.ForEach(y => { 
                String buffer = ""; 
                List<String> place = ListOfVideos.Where(x=>x.Contains(y)).ToList(); //get element
                if (place.Count != 0) // safety
                {
                    // swap
                    buffer = place[0]; 
                    ListOfVideos.Remove(buffer);
                    if (ListOfVideos.Count > 0) 
                        ListOfVideos.Insert(1, buffer);
                    else ListOfVideos.Add(buffer);
                }
            });
            // first named 
            ListOfVideos.Where(x => { // is contains some staff after _ sign
                bool state = true;
                music_staff.ForEach(y => {
                    if (x.Contains(y)) state = false;
                });
                return state;
            })
                .ToList().ForEach(x => {
                    ListOfVideos.Remove(x);
                    ListOfVideos.Insert(0, x);
                });
        }

        /*
        void sort_p_type()
        {
            var result = fileList.Where(fileName => !Regex.IsMatch(fileName, @"p\d+\.mp4$"));
        }
        */

    }
}
