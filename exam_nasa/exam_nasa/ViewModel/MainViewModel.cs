using exam_nasa.Infrastructure;
using exam_nasa.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa.ViewModel
{
    class MainViewModel : Notifier
    {
        HttpClient client = new HttpClient();
        string BaseUrl => "https://api.nasa.gov/DONKI/CME?startDate=2019-05-10&endDate=2019-11-11&api_key=lrBmM0yeF0F2YPKojkfieUXagAMRbBghbZPecQK6";
        string apiKey => "https://api.nasa.gov/DONKI/CME?startDate=2019-05-10&endDate=2019-11-11&api_key=lrBmM0yeF0F2YPKojkfieUXagAMRbBghbZPecQK6";
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
        public MainViewModel()
        {
            Task.Run(() =>
            {
                Apod = GetUnits.GetApod();
            });
        }
    }
}
