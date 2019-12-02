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
using System.Threading.Tasks;
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

        string pathVideo;
        public string PathVideo
        {
            get => pathVideo;
            set
            {
                pathVideo = value;
                Notify();
            }
        }
        public MainViewModel()
        {
            Apod = new APOD();
            Apod = GetUnits.GetApod();

            Task.Run(() =>
            { GetVideo(); });
        }

        void GetVideo()
        {
            //WebClient client = new WebClient();
            //client.DownloadFile("https://www.youtube.com/embed/ofZTOxC9JQ4?rel=0", @"../Video");

            var youtube = YouTube.Default;
            var video = youtube.GetVideo("https://youtu.be/ofZTOxC9JQ4");
            File.WriteAllBytes($"../video.mpg", video.GetBytes());
            PathVideo = $"../video.mpg";
        }
    }
}
