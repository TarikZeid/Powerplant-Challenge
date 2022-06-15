using Microsoft.AspNetCore.Mvc;
using Powerplant_Challenge.Business.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Powerplant_Challenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        private IProductionPlanBusiness _productionPlanBusiness;
        public ProductionPlanController(IProductionPlanBusiness productionPlanBusiness_) 
        {
            _productionPlanBusiness = productionPlanBusiness_;
        }

        [HttpPost]
        public ActionResult CalculatePower([FromBody] PayLoad payLoad)
        {
            return Ok(_productionPlanBusiness.GenerateProductionPlan(payLoad));
        }
    }
}
