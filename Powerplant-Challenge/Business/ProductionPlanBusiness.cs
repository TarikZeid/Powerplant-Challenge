using Powerplant_Challenge.Business.Interfaces;
using Shared.Helper;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Powerplant_Challenge.Business
{
    public class ProductionPlanBusiness : IProductionPlanBusiness
    {
        public List<PowerPlantResponse> GenerateProductionPlan(PayLoad payLoad)
        {
            List<PowerPlantResponse> powerPlantResponses = new List<PowerPlantResponse>();

            CalculPriceAndMax(payLoad);

            // To minimize the production cost, the list should be sorted by priority.
            payLoad.PowerPlants = payLoad.PowerPlants.OrderBy(p => p.Price).ThenByDescending(p => p.Pmax).ToList();

            payLoad.PowerPlants.ForEach(p =>
            {
                if (payLoad.Load <= 0)
                {
                    // We do not need more energy because we have generated enough.
                    powerPlantResponses.Add(new PowerPlantResponse(p.Name, 0));
                }
                else if (payLoad.Load <= p.Pmax)
                {
                    // we need less energy than the maximum that this source can produce
                    powerPlantResponses.Add(new PowerPlantResponse(p.Name, payLoad.Load));
                    payLoad.Load = 0;
                }
                else 
                {
                    powerPlantResponses.Add(new PowerPlantResponse(p.Name, p.Pmax));
                    payLoad.Load -= p.Pmax;
                }
            });

            return powerPlantResponses;
        }

        // This method allows to calculate the price of each type and the power max for wind turbines
        private void CalculPriceAndMax(PayLoad payLoad) 
        {
            payLoad.PowerPlants.ForEach(p =>
            {
                switch (p.Type)
                {
                    case PowerPlantType.Gasfired:
                        p.Price = payLoad.Fuels.Gas / p.Efficiency;
                        break;

                    case PowerPlantType.Turbojet:
                        p.Price = payLoad.Fuels.Kerosines / p.Efficiency;
                        break;

                    default:
                        // Wind turbines do not need fuel and therefore there is no charge
                        p.Price = 0;
                        // The maximum value that the wind turbines produce depends on the wind  
                        p.Pmax = p.Pmax * payLoad.Fuels.Wind / 100;
                        break;
                }
            });

            // We delete all the prices that contain Infinity because they are caused by the division by a zero
            payLoad.PowerPlants.RemoveAll(r => float.IsInfinity(r.Price));
        }


    }
}
