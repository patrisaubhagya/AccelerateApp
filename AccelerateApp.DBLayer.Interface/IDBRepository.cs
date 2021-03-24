using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AccelerateApp.DBLayer.Interface
{
  public  interface IDBRepository
    {
        DataSet getDataSetfromSP(dynamic parameter, string tableName);
    }
}
