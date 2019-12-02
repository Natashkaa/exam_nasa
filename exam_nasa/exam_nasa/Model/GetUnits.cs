using exam_nasa.NasaApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa.Model
{
    class GetUnits
    {
        NetworkManager manager = new NetworkManager();
        public static APOD GetApod()
        {
            string path = "../Apod.json";
            ApiConfig.AddUrl = @"planetary/apod";
            string query = $"{ApiConfig.BaseUrl}/{ApiConfig.AddUrl}?api_key={ApiConfig.Api_Key}";

            IOFile.SaveToFile(query, path);
            //JToken strApod = IOFile.ReadFromFile(path);
            string desJson = IOFile.ReadFromFile(path);
            APOD apod = JsonConvert.DeserializeObject<APOD>(desJson);
            return apod;
        }
    }
}
