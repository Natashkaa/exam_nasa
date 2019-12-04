using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa.Model
{
    internal class Asteroids_NeoWs
    {
        [JsonProperty(PropertyName = "element_count")]
        public int Count { get; set; }
        [JsonProperty(PropertyName = "near_earth_objects")]
        public NearEarthObject NearObjects { get; set; }
    }
    internal class NearEarthObject//near_earth_objects
    {
        [JsonProperty(PropertyName = "2019-12-03")]
        public ObservableCollection<Date> Start_Date { get; set; }

        [JsonProperty(PropertyName = "2019-12-04")]
        public ObservableCollection<Date> End_Date { get; set; }
    }
    internal class Date
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "absolute_magnitude_h")]
        public string Absolute_Magnitude { get; set; }
        [JsonProperty(PropertyName = "estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }
        [JsonProperty(PropertyName = "nasa_jpl_url")]
        public string NasaJplUrl { get; set; }
    }
    internal class EstimatedDiameter
    {
        [JsonProperty(PropertyName = "kilometers")]
        public Kilometers Kilometers { get; set; }
        [JsonProperty(PropertyName = "is_potentially_hazardous_asteroid	")]
        public bool IsPotentiallyHazardous { get; set; }

        public override string ToString()
        {
            return $"Is potentially_Hazardous_Asteroid:\n{IsPotentiallyHazardous}";
        }
    }
    internal class Kilometers
    {
        [JsonProperty(PropertyName = "estimated_diameter_min")]
        public string Diameter_Min { get; set; }
        [JsonProperty(PropertyName = "estimated_diameter_max")]
        public string Diameter_Max { get; set; }

        public override string ToString()
        {
            return $"Estimated Diameter Min - {Diameter_Min};\nEstimated Diameter Max - { Diameter_Max}; ";
        }
    }
    
}
