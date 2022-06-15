using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Fuel
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public float Gas { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public float Kerosines { get; set; }
        
        [JsonPropertyName("co2(euro/ton)")]
        public float Co2 { get; set; }
        
        [JsonPropertyName("wind(%)")]
        public int Wind { get; set; }
    }
}
