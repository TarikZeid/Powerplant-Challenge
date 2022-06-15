using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Powerplant_Challenge.Business.Interfaces
{
    public interface IProductionPlanBusiness
    {
        List<PowerPlantResponse> GenerateProductionPlan(PayLoad payLoad);
    }
}
