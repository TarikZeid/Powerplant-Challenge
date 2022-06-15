using Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared.Models
{
    public class PowerPlant
    {
        public string Name { get; set; }
        public PowerPlantType Type { get; set; }
        public float Efficiency { get; set; }
        public int Pmin { get; set; }
        public int Pmax { get; set; }

        [JsonIgnore]
        public float Price { get; set; }
    }
}
