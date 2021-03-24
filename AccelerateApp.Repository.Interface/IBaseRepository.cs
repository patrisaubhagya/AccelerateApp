using AccelerateApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccelerateApp.Repository.Interface
{
    public interface IBaseRepository
    {
        Task<List<BaseVertical>> GetVerticalData();
        Task<List<BaseHorizantal>> GetHorizantalData();

    }
}
