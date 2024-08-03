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
    class VideoFile
    {
        //types are made for Video the class of YT lib
        public String FileName = "";
        public String Title = "";
        public String Description = "";
        public String[] Tags = new string[] { }; //  { "tag1", "tag2" };
        public String CategoryID= "22";
        public DateTime PublishedDate = new DateTime();
        public String Id = "";

        public bool Uploaded = false;
        public bool Published = false;
        public bool IsHaveCEOfile = false;

        public VideoFile(String filename)
        {
            FileName = filename;
        }
        public VideoFile(String filename, string pathToCEO)
        {
            FileName = filename;
            putCEOInfo(pathToCEO+"\\"+filename+".txt");
        }
        public VideoFile(String filename, DateTime date)
        {
            FileName = filename;
            PublishedDate = date;
        }

        public void setPDate(DateTime dateTime) { PublishedDate = dateTime; }

        public void saveCEOInfo(String path)
        {
            if (!path.Contains("CEO")) path += "\\CEO"; //comfort
            if (!Directory.Exists(path)) Directory.CreateDirectory(path); //safety
            
            //check to not delete important info
            if ( Title == "" || Description == "" || Tags.Length == 0 )
            {
                var a = new VideoFile(FileName, path);
                if (a.Title != "") return;
                if (a.Description != "") return;
               // if (a.Tags.Length != 0) return;
            }

            String message = "";
            message += $"FileName ~ {FileName}";
            message += "\r\n";
            message += $"Title ~ {Title}";
            message += "\r\n";
            message += $"Description ~ {Description}";
            message += "\r\n";
            message += $"Tags ~ "; 
            message += string.Join(", ", Tags);
            message += "\r\n";
            message += $"CategoryID ~ {22}";
            message += "\r\n";
            message += $"PublishedDate ~ {PublishedDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)}";
            message += "\r\n";
            message += "\r\n";
            message += $"Uploaded ~ {Uploaded}";
            message += "\r\n";
            message += $"Published ~ {Published}";
            message += "\r\n";
            message += $"Id ~ {Id}";

            File.WriteAllText(path + $"\\{FileName}.txt", message);
            IsHaveCEOfile = true;
        }

        public void putCEOInfo(String pathToFile)
        {
            // Comfortness for this method
            if (!pathToFile.Contains(FileName)) // If this is path to CEO directory - not to file
                pathToFile += $"\\{FileName}.txt";

            // Safety existings
            if (!File.Exists(pathToFile)) return;

            string fileContent = File.ReadAllText(pathToFile); // Read the entire file content
            List<String> lines = fileContent.Split('\n').ToList(); // Split the content into lines

            string multilineDescription = "";
            bool isDescription = false;

            lines.ForEach(x => // For each line (parameter)
            {
                List<String> parameters = x.Split('~').ToList(); // Slice it to name and value
                if (parameters.Count > 0) // If there's not an empty line
                {
                    switch (parameters[0].Trim()) // See name of parameter
                    {
                        case "FileName":
                            FileName = parameters[1].Trim();
                            break;
                        case "Title":
                            Title = parameters[1].Trim();
                            break;
                        case "Description":
                            isDescription = true;
                            multilineDescription = parameters[1].Trim();
                            break;
                        case "Tags":
                            if (parameters[1].Trim().Length < 470)
                                Tags = parameters[1].Trim().Split(',').ToList().Select(y => y.Trim()).ToArray();
                            else
                                Tags = parameters[1].Trim().Substring(0, 470).Split(',').ToList().Select(y => y.Trim()).ToArray(); // Safety over 500 symbols 
                            break;
                        case "CategoryID":
                            CategoryID = parameters[1].Trim();
                            break;
                        case "PublishedDate":
                            PublishedDate = parameters[1].toDateTime();
                            break;
                        case "Uploaded":
                            Uploaded = Convert.ToBoolean(parameters[1].Trim());
                            break;
                        case "Published":
                            Published = Convert.ToBoolean(parameters[1].Trim());
                            break;
                        case "Id":
                            Id = parameters[1].Trim();
                            break;
                        default:
                            if (isDescription) // If still reading the description
                                multilineDescription += "\n" + x.Trim();
                            break;
                    }
                }
            });

            if (isDescription)
                Description = multilineDescription.Trim();

            IsHaveCEOfile = true;

            Description = Description.Replace("{descr}", Settings.Default.def_descr);
            Description = Description.Replace("<", "");
            Description = Description.Replace(">", "");
            Title = Title.Replace(">", "");
            Title = Title.Replace(">", "");
            if (Title.Length >= 99) Title = Title.Substring(0, 99);
        }

        //
    }
}
