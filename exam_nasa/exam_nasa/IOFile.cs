using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa
{
    class IOFile
    {
        public static void SaveToFile(string source, string path)
        {
            if (!File.Exists(path))
            {
                string json = NetworkManager.GetJson(source);
                File.WriteAllText(path, json);
            }
        }
        public static string ReadFromFile(string path)
        {
            string json = File.ReadAllText(path);
            return json;
        }
    }
}
