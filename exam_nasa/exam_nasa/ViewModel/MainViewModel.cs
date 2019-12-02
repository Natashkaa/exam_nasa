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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoLibrary;

namespace exam_nasa.ViewModel
{
    class MainViewModel : Notifier
    {
        //string BaseUrl => "https://api.nasa.gov/DONKI/CME?startDate=2019-05-10&endDate=2019-11-11&api_key=lrBmM0yeF0F2YPKojkfieUXagAMRbBghbZPecQK6";
        //string apiKey => "https://api.nasa.gov/DONKI/CME?startDate=2019-05-10&endDate=2019-11-11&api_key=lrBmM0yeF0F2YPKojkfieUXagAMRbBghbZPecQK6";
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

        string pathPod;
        public string PathPod
        {
            get => pathPod;
            set
            {
                pathPod = value;
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

        ICommand closeWindow;
        public ICommand CloseWindow => closeWindow ?? (closeWindow = new RelayCommand(x =>
        {
            
        }));

        Thread updateDateNowThread;
        public MainViewModel()
        {
            updateDateNowThread = new Thread(Updatedate);
            updateDateNowThread.Start();

            Apod = new APOD();
            Apod = GetUnits.GetApod();
            if (apod.Media_Type == "video")
            {
                Task.Run(() =>
                { GetVideo(); });
            }
            else if (apod.Media_Type == "image")//mb
            {
                //
            }



        }

        void GetVideo()
        {
            var youtube = YouTube.Default;
            var video = youtube.GetVideo("https://youtu.be/ofZTOxC9JQ4");
            PathPod = $"../../Video/{apod.Title}.mpg";
            File.WriteAllBytes(PathPod, video.GetBytes());
        }
        void Updatedate()
        {
            while (true)
            {
                DateNow = DateTime.Now.ToString();
            }
        }
    }
}
