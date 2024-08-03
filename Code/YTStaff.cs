using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using YLoader.Properties;

namespace YLoader
{
    public partial class Form1 : Form
    {
        //YouTube Staff
        public class YTStaff
        {
            public YouTubeService service, youtubeService, service3;
                UserCredential credential2, credential3; //credential
            public List<PlaylistItem> own_videos = new List<PlaylistItem>();
            public String channel_name = "";
            public YTStaff()
            {
                make_service();
            }
            async void make_service()
            {

/*                //UserCredential credential;
                //For Upload
                using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    IEnumerable<string> scopes = new string[] { "https://www.googleapis.com/auth/youtube.upload" };
                    //IEnumerable<string> scopes2 = new string[] { "https://www.googleapis.com/youtube/v3/playlistItems" };
                    //IEnumerable<string> scopes ;
                    // Enum.TryParse<string>("https://www.googleapis.com/auth/youtube.upload", out IEnumerable<string> scopes);

                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets, scopes,
                        "user", CancellationToken.None, new FileDataStore("Videos.ListMyLibrary"));
                }

                // Create the service.
                service = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "yloader",
                });*/

                /////////////////////////////////////////////////////////////////////////////////////////
                //For List
                //UserCredential credential2;
                using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    credential2 = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets, new[] { YouTubeService.Scope.YoutubeReadonly },
                        "user", CancellationToken.None, new FileDataStore(this.GetType().ToString())
                    );
                }
                youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential2,
                    ApplicationName = this.GetType().ToString()
                });
                /////////////////////////////////////////////////////////////////////////////////////////
                //For Update
                //UserCredential credential3;
                using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    credential3 = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets, new string[] { "https://www.googleapis.com/auth/youtube.force-ssl" },
                        "user", CancellationToken.None, new FileDataStore("Videos")
                    );
                }
                service3 = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential3,
                    ApplicationName = "yloader",
                });

            }

            public void Disconnect()
            {
                //credential.RevokeTokenAsync(CancellationToken.None).Wait();
                credential2.RevokeTokenAsync(CancellationToken.None).Wait();
                credential3.RevokeTokenAsync(CancellationToken.None).Wait();
            }

            public void Refresh()
            {
                //credential.RefreshTokenAsync(CancellationToken.None).Wait();
                credential2.RefreshTokenAsync(CancellationToken.None).Wait();
                credential3.RefreshTokenAsync(CancellationToken.None).Wait();
                Disconnect();
               // make_service();
            }
/*
            void videosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
            {
                switch (progress.Status)
                {
                    case UploadStatus.Uploading:
                        Console.WriteLine("{0} bytes sent.", progress.BytesSent);
                        break;

                    case UploadStatus.Failed:
                        Console.WriteLine("An error prevented the upload from completing.\n{0}", progress.Exception);
                        break;
                }
            }

            void videosInsertRequest_ResponseReceived(Video video)
            {
                Console.WriteLine("Video id '{0}' was successfully uploaded.", video.Id);
            }

            public async void UploadVideo(VideoFile vFile, String path)
            {
                Video video = new Video();
                video.Snippet = new VideoSnippet();
                video.Snippet.Title = vFile.Title;
                video.Snippet.Description = vFile.Description;
                video.Snippet.Tags = vFile.Tags;
                video.Snippet.CategoryId = vFile.CategoryID; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
                video.Status = new VideoStatus();
                video.Status.PrivacyStatus = "private"; // or "private" or "public" // "unlisted" - доступ по ссылке
                var filePath = $"{path}\\{vFile.FileName}.mp4";

                video.Status.PublishAt = vFile.PublishedDate.AddHours(13);

                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    var videosInsertRequest = service.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                    videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                    videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;

                    await videosInsertRequest.UploadAsync();
                }
            }
*/
            internal async void UpdateVideo(VideoFile vFile, int hours = 13)
            {
                Video video = new Video();
                video.Id = vFile.Id;
                video.Snippet = new VideoSnippet();
                video.Snippet.Title = vFile.Title;
                video.Snippet.Description = vFile.Description;
                video.Snippet.Tags = vFile.Tags;
                video.Snippet.CategoryId = vFile.CategoryID; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
                video.Status = new VideoStatus();
                video.Status.PrivacyStatus = "private"; // or "private" or "public" // "unlisted" - доступ по ссылке

                video.Status.PublishAt = vFile.PublishedDate.AddHours(hours);


                var videosInsertRequest = service3.Videos.Update(video, "snippet,status");
                await videosInsertRequest.ExecuteAsync();
            }

           internal async void ThumbnailSetResponse (VideoFile video)
            {
                try
                {
                    // Initial validation.
                    if (service3 == null)
                        throw new ArgumentNullException("service");

                    if (video.Id == null)
                        throw new ArgumentNullException(video.Id);

                    //GET STREAM
                    String filePath = Settings.Default.active_path + $"/{video.FileName.Replace(".mp4","").Replace(".png","")}.png";
                    using (var fileStream = new FileStream(filePath, FileMode.Open))
                    {
                    // Building the initial request.
                    var request = service3.Thumbnails.Set(video.Id,fileStream, "image/png");

                    // Applying optional parameters to the request.                
                    //request = (ThumbnailsResource.SetRequest)SampleHelpers.ApplyOptionalParms(request, null);

                    // Requesting data.
                    await request.UploadAsync();
                    }
                    return;
                }
                catch (Exception ex)
                {
                    throw new Exception("Request Thumbnails.Set failed.", ex);
                }
            }

            public async Task<Task> getListOfMyVideos()
            {
                List<PlaylistItem> listofmyvideos = new List<PlaylistItem>();
                //var request = service.Videos.List("snippet"); //"snippet,contentDetails,statistics"
                var channelsListRequest = youtubeService.Channels.List("contentDetails");
                channelsListRequest.Mine = true;

                // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
                var channelsListResponse = await channelsListRequest.ExecuteAsync();

                foreach (var channel in channelsListResponse.Items)
                {
                    // From the API response, extract the playlist ID that identifies the list
                    // of videos uploaded to the authenticated user's channel.
                    var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;

                    Console.WriteLine("Videos in list {0}", uploadsListId);

                    var nextPageToken = "";
                    while (nextPageToken != null)
                    {
                        var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
                        playlistItemsListRequest.PlaylistId = uploadsListId;
                        playlistItemsListRequest.MaxResults = 50;
                        playlistItemsListRequest.PageToken = nextPageToken;
                        
                        // Retrieve the list of videos uploaded to the authenticated user's channel.
                        var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();

                        foreach (var playlistItem in playlistItemsListResponse.Items)
                        {
                            // Print information about each video.
                            Console.WriteLine("{0} ({1})", playlistItem.Snippet.Title, playlistItem.Snippet.ResourceId.VideoId);
                        }
                        listofmyvideos.AddRange(playlistItemsListResponse.Items);//add 50 videos

                        nextPageToken = playlistItemsListResponse.NextPageToken;
                    }
                }
                own_videos = listofmyvideos; //get all
                return Task.CompletedTask;
            }
            /*
               public String formatName()
            {

                String ret_title = "";
                List <String> title_words = channel_name.Split(' ').Where(x => x.Trim() != "").ToList(); //split to words
                if (title_words.Count > 1) //if more than 2 words in name
                    title_words.ForEach(x => ret_title += x.ToUpper()[0]); //return title with only first letters
                else ret_title = Regex.Replace(ret_title, "[aeiouyAEIOUYаеёиоуыэюяАЕЁИОУЫЭЮЯ]", "");

                return ret_title.Substring(0,2);
            }
            async Task<Task> getName ()
            {
                var channelsListRequest = youtubeService.Channels.List("contentDetails");
                channelsListRequest.Mine = true;

                // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
                var channelsListResponse = await channelsListRequest.ExecuteAsync();
                channel_name = channelsListResponse.Items.First().Snippet.Title;
                Console.WriteLine(channel_name);
                Console.WriteLine(channel_name);
                Console.WriteLine(channel_name);
                Console.WriteLine(channel_name);
                Console.WriteLine(channel_name);
                return Task.CompletedTask;
            }
             */
            //
        }

        /*
        /// <summary>
        /// WORKS 
        /// </summary>
        async void RunSomethink()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                IEnumerable<string> scopes = new string[] { "https://www.googleapis.com/auth/youtube.upload" };
                //IEnumerable<string> scopes ;
                // Enum.TryParse<string>("https://www.googleapis.com/auth/youtube.upload", out IEnumerable<string> scopes);

                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, scopes,
                    "user", CancellationToken.None, new FileDataStore("Videos.ListMyLibrary"));
            }

            // Create the service.
            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "yloader",
            });

            Video video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = "TestTitle";
            video.Snippet.Description = "TestDescription";
            video.Snippet.Tags = new string[] { "tag1", "tag2" };
            video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            video.Status = new VideoStatus();
            video.Status.PrivacyStatus = "unlisted"; // or "private" or "public" // "unlisted" - доступ по ссылке
            //video.Snippet.PublishedAt = DateTime.Now;
            var filePath = @"C:\Users\vadymkon\Desktop\test.mp4";

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = service.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;

                await videosInsertRequest.UploadAsync();
            }
        }

        void videosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
        {
            switch (progress.Status)
            {
                case UploadStatus.Uploading:
                    Console.WriteLine("{0} bytes sent.", progress.BytesSent);
                    break;

                case UploadStatus.Failed:
                    Console.WriteLine("An error prevented the upload from completing.\n{0}", progress.Exception);
                    break;
            }
        }

        void videosInsertRequest_ResponseReceived(Video video)
        {
            Console.WriteLine("Video id '{0}' was successfully uploaded.", video.Id);
        }
        */
    }
}
