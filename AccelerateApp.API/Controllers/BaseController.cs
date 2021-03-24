using AccelerateApp.Business.Interface;
using AccelerateApp.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccelerateApp.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {
        private IBaseManager _IBaseManager;

        public BaseController(IBaseManager IBaseManager)
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
