using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace AccelerateApp.DBLayer.Interface
{
    public interface IDapperRepository
    {
        Task<IEnumerable<T>> GetAll<T>(string query, object parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
