using exam_nasa.Infrastructure;
using exam_nasa.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa.ViewModel
{
    class MainViewModel : Notifier
    {
        HttpClient client = new HttpClient();
        string BaseUrl => "https://api.nasa.gov/planetary/apod?api_key=lrBmM0yeF0F2YPKojkfieUXagAMRbBghbZPecQK6";
        string apiKey => "lrBmM0yeF0F2YPKojkfieUXagAMRbBghbZPecQK6";
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
            string query = $"{BaseUrl}";
            var res = client.GetAsync(query).Result;
            string tmp = res.Content.ReadAsStringAsync().Result;
            JObject jobj = JObject.Parse(tmp);
            Apod = jobj.ToObject<APOD>();
        }
    }
}
