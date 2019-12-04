using exam_nasa.Infrastructure;
using exam_nasa.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoLibrary;

namespace exam_nasa.ViewModel
{
    class MainViewModel : Notifier
    {
        APOD apod;
        public APOD Apod
        {
            get => apod;
            set
            {
                apod = value;
                Notify();
            }
        }

        string imagePod;
        public string ImagePod
        {
            get => imagePod;
            set
            {
                imagePod = value;
                Notify();
            }
        }
        string videoPod;
        public string VideoPod
        {
            get => videoPod;
            set
            {
                videoPod = value;
                Notify();
            }
        }
        
        string dateNow;
        public string DateNow
        {
            get => dateNow;
            set
            {
                dateNow = value;
                Notify();
            }
        }

        string timeNow;
        public string TimeNow
        {
            get => timeNow;
            set
            {
                timeNow = value;
                Notify();
            }
        }

        Thread updateDateNowThread;
        public MainViewModel()
        {
            updateDateNowThread = new Thread(Updatedate);
            updateDateNowThread.IsBackground = true;
            updateDateNowThread.Start();
            
            Apod = new APOD();
            Apod = GetUnits.GetApod();
            
            if (apod.Media_Type == "video")
            {
                Task.Run(() =>
                { GetVideo(); });
            }
            else if (apod.Media_Type == "image")
            {
                ImagePod = Apod.Url;
                Task.Run(() =>
                { GetImage(); });
            }
            
        }

        void GetVideo()
        {
            string path = $"../../Video/{apod.Title}.mpg";
            if (!File.Exists(path))
            {
                var youtube = YouTube.Default;
                var video = youtube.GetVideo("https://youtu.be/ofZTOxC9JQ4");
                File.WriteAllBytes(path, video.GetBytes());
            }
            VideoPod = path;
            ImagePod = "";
            
            
        }
        void GetImage()
        {
            string GoodTitle = Regex.Replace(Apod.Title, @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            string path = "../../Images/" + GoodTitle + ".jpg";
            if (!File.Exists(path))
            {
                string url = Apod.Url;
                WebClient client = new WebClient();
                client.DownloadFile(url, path);
            }
            
            VideoPod = "";
            
        }
        void Updatedate()
        {
            while (true)
            {
                DateNow = $"{DateTime.Now.Year} - {DateTime.Now.Month} - {DateTime.Now.Day}";
                TimeNow = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
            }
        }
        
    }
}
