using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa.NasaApi
{
    class ApiConfig
    {
        public static string BaseUrl { get; } = @"https://api.nasa.gov";
        public static string AddUrl { get; set; }
        public static string Start_Date { get; set; }
        public static string End_Date { get; set; }
        public static string Api_Key { get; } = "lrBmM0yeF0F2YPKojkfieUXagAMRbBghbZPecQK6";
    }
}
