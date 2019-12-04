using exam_nasa.NasaApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa.Model
{
    class GetUnits
    {
        NetworkManager manager = new NetworkManager();
        public static APOD GetApod(bool needUpdate)
        {
            string path = "../Apod.json";
            if (needUpdate)
            {
                File.Delete(path);
            }
            
            if (!File.Exists(path))
            {
                ApiConfig.AddUrl = @"planetary/apod";
                string query = $"{ApiConfig.BaseUrl}/{ApiConfig.AddUrl}?api_key={ApiConfig.Api_Key}";
                IOFile.SaveToFile(query, path);
            }
            string desJson = IOFile.ReadFromFile(path);
            APOD apod = JsonConvert.DeserializeObject<APOD>(desJson);
            return apod;
        }
        public static NearEarthObject GetAsteroids()
        {
            string path = "../Asteroids.json";
            if (!File.Exists(path))
            {
                ApiConfig.AddUrl = @"neo/rest/v1/feed";
                //string start = $"{DateTime.Now.AddDays(-1).Year}-{DateTime.Now.AddDays(-1).Month}-{DateTime.Now.AddDays(-1).Day}";
                //string end = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
                ApiConfig.Start_Date = "2019-12-03";
                ApiConfig.End_Date = "2019-12-04";
                string query = $"{ApiConfig.BaseUrl}/{ApiConfig.AddUrl}?start_date={ApiConfig.Start_Date}&end_date={ApiConfig.End_Date}&api_key={ApiConfig.Api_Key}";
                IOFile.SaveToFile(query, path);
            }
            string desJson = IOFile.ReadFromFile(path);
            Asteroids_NeoWs asteroids_NeoWs = JsonConvert.DeserializeObject<Asteroids_NeoWs>(desJson);
            return asteroids_NeoWs.NearObjects;
        }
    }
}
