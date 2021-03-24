using AccelerateApp.DBLayer.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace AccelerateApp.DBLayer
{
    public class DapperRepository: IDapperRepository
    {
        private string _connectionString;
        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> GetAll<T>(string query, object parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<T>(query, parameters, commandType: commandType);
            }
        }
    }
}
