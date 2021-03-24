using AccelerateApp.DBLayer;
using AccelerateApp.DBLayer.Interface;
using AccelerateApp.Entities;
using AccelerateApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccelerateApp.Repository
{
    public class BaseRepository : IBaseRepository
    {
        DataSet ds = new DataSet();

        private IDBRepository _IDB;
        private readonly IDapperRepository _idrp;

        public BaseRepository(IDBRepository _idb, IDapperRepository idrp)
        {
            _IDB = _idb;
            _idrp = idrp;
        }

        public List<BaseVertical> Getv1()
        {
            List<BaseVertical> objBase = new List<BaseVertical>();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Flag", 1);
            ds = _IDB.getDataSetfromSP(param, "USP_AT_DeliveryUnit");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objBase = ds.Tables[0].AsEnumerable().Select(m => new BaseVertical
                    {
                        _Vertical = m["Vertical"] != DBNull.Value ? m["Vertical"].ToString() : "",
                    }).ToList();
                }
            }
            ds.Dispose();
            return objBase;
        }

        public async Task<List<BaseVertical>> GetVerticalData()
        { 
            var Items = await _idrp.GetAll<BaseVertical>(App_Constants.sp_DeliveryUnit, new { Flag = 1 });
            return Items.ToList(); 
        }
        public async Task<List<BaseHorizantal>> GetHorizantalData()
        {
            var Items = await _idrp.GetAll<BaseHorizantal>(App_Constants.sp_DeliveryUnit, new { Flag = 2 });
            return Items.ToList();
        }
    }
}
