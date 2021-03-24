using AccelerateApp.Business.Interface;
using AccelerateApp.Entities;
using AccelerateApp.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccelerateApp.Business
{
  public class BaseManager : IBaseManager
    {
        private IBaseRepository _IBaseRepository;

        public BaseManager(IBaseRepository IBaseRepository)
        {
            _IBaseRepository = IBaseRepository;
        }


       public Task<List<BaseVertical>> GetVerticalData()
        {
            return _IBaseRepository.GetVerticalData();
        }
        public Task<List<BaseHorizantal>> GetHorizantalData()
        {
            return _IBaseRepository.GetHorizantalData();
        }
    }
}
