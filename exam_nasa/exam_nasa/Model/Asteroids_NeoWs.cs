using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa.Model
{
    class Asteroids_NeoWs
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "neo_reference_id")]
        public int Neo_reference_Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "nasa_jpl_url")]
        public string Nasa_jpl_Url { get; set; }
        [JsonProperty(PropertyName = "absolute_magnitude_h")]
        public double Absolute_Magnitude { get; set; }
        
    }
}
