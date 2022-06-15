using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class PowerPlantResponse
    {
        public string Name { get; set; }
        public int P { get; set; }

        public PowerPlantResponse(string name, int p) 
        {
            this.Name = name;
            this.P = p;
        }
    }
}
