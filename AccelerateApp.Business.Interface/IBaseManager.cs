using AccelerateApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccelerateApp.Business.Interface
{
   public interface IBaseManager 
    {
        Task<List<BaseVertical>> GetVerticalData();
        Task<List<BaseHorizantal>> GetHorizantalData();

       // these 2 methods of interface 

    }
}
