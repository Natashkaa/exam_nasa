using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa.Model
{
    class APOD
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "explanation")]
        public string Explanation { get; set; }
        [JsonProperty(PropertyName = "media_type")]
        public string Media_Type { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
