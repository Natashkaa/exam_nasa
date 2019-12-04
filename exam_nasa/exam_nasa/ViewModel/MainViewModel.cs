using exam_nasa.Infrastructure;
using exam_nasa.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VideoLibrary;

namespace exam_nasa.ViewModel
{
    class MainViewModel : Notifier
    {
        #region fields
        APOD apod;
        NearEarthObject nearEarthObject;
        ObservableCollection<Date> asteroidsList;
        Date selectedAsteroid;
        string imagePod;
        string videoPod;
        string dateNow;
        string timeNow;
        ICommand updateCommand;
        ICommand clickUrl;
        Thread updateDateNowThread;
        #endregion

        #region Properties
        public APOD Apod
        {
            get => apod;
            set
            {
                apod = value;
                Notify();
            }
        }
        public ObservableCollection<Date> AsteroidsList
        {
            get => asteroidsList;
            set
            {
                asteroidsList = value;
                Notify();
            }
        }
        public Date SelectedAsteroid
        {
            get => selectedAsteroid;
            set
            {
                selectedAsteroid = value;
                Notify();
            }
        }
        public string ImagePod
        {
            get => imagePod;
            set
            {
                imagePod = value;
                Notify();
            }
        }
        public string VideoPod
        {
            get => videoPod;
            set
            {
                videoPod = value;
                Notify();
            }
        }
        public string DateNow
        {
            get => dateNow;
            set
            {
                dateNow = value;
                Notify();
            }
        }
        public string TimeNow
        {
            get => timeNow;
            set
            {
                timeNow = value;
                Notify();
            }
        }
        #endregion

        #region Commands
        public ICommand UpdateCommand => updateCommand ?? (updateCommand = new RelayCommand(x => GetAllUnits(true)));
        public ICommand ClickUrl => clickUrl ?? (clickUrl = new RelayCommand(x => Process.Start(SelectedAsteroid.NasaJplUrl)));
        #endregion


        public MainViewModel()
        {
            updateDateNowThread = new Thread(Updatedate);
            updateDateNowThread.IsBackground = true;
            updateDateNowThread.Start();
            GetAllUnits(false);
        }

        void GetAllUnits(bool needUpdate)
        {
            Apod = new APOD();
            Task.Run(() =>
            {
                Apod = GetUnits.GetApod(needUpdate);
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
            });
            Task.Run(() =>
            {
                nearEarthObject = GetUnits.GetAsteroids();
                AsteroidsList = new ObservableCollection<Date>();
                foreach (var item in nearEarthObject.Start_Date)
                {
                    AsteroidsList.Add(item);
                }
                foreach (var item in nearEarthObject.End_Date)
                {
                    AsteroidsList.Add(item);
                }

            });
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
