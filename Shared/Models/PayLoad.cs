using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class PayLoad
    {
        public int Load { get; set; }
        public Fuel Fuels { get; set; }
        public List<PowerPlant> PowerPlants { get; set; }
    }
}
