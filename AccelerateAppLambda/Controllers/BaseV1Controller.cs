using AccelerateApp.Business.Interface;
using AccelerateApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccelerateAppLambda.Controllers
{ 
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseV1Controller : ControllerBase
    {
        private IBaseManager _IBaseManager;

        public BaseV1Controller(IBaseManager IBaseManager)
        {
            _IBaseManager = IBaseManager;
        }


        [HttpGet]
        [Route("api/{v:apiVersion}/GetVerticalData")]
        public Task<List<BaseVertical>> GetVerticalData()
        {
            return _IBaseManager.GetVerticalData();
        }

        [HttpGet]
        [Route("api/{v:apiVersion}/GetHorizantalData")]
        public Task<List<BaseHorizantal>> GetHorizantalData()
        {
            return _IBaseManager.GetHorizantalData();
        }
    }
}
