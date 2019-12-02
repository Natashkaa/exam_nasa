using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa
{
    class NetworkManager
    {
        public static string GetJson(string url)
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync(url).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}
