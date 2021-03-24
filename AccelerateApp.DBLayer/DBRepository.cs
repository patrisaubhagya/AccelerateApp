using AccelerateApp.DBLayer.Interface;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccelerateApp.DBLayer
{
    public class DBRepository : IDBRepository
    {
        DataSet ds = new DataSet();
        private string connectionString = App_Constants.DB_Local_CoonectionString;
       
            public DataSet getDataSetfromSP(dynamic parameter, string tableName)
        {
           
            SqlDataAdapter Adp = new SqlDataAdapter();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand Cmd = new SqlCommand();
                    Cmd.Connection = connection;
                    Cmd.CommandText = tableName;
                    Cmd.CommandTimeout = 0;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    if (parameter != null)
                    {
                        foreach (SqlParameter sqlParam in parameter)
                        {
                            try
                            {
                                Cmd.Parameters.Add(sqlParam);
                            }
                            catch
                            {

                            }
                        }
                    }
                    Adp = new SqlDataAdapter(Cmd);
                    ds = new DataSet();
                    Adp.Fill(ds, tableName);
                    Cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                   //
                }
                finally
                {
                    Adp.Dispose();
                    connection.Close();
                    connection.Dispose();
                }
            }

            return ds;
        }
    }

    public static class App_Constants
    {
        public static readonly string DB_Local_CoonectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AccelerateDB;Integrated Security=true;";


        public static readonly string sp_DeliveryUnit = "USP_AT_DeliveryUnit";
    }
}
