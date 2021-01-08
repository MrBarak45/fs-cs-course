using System;
using System.Data;
using System.Data.SqlClient;

namespace FS_CSProject
{
    //[ServiceBehaviour(ConcurrencyMode=ConcurrencyMode.Single)]
    public class Connector : IConnector
    {
        private SqlConnection _sqlConnection;

        public Connector(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public int BulkInsert(DataTable dt, string target)
        {
            try
            {
                using (SqlBulkCopy bc = new SqlBulkCopy(this._sqlConnection))
                {
                    bc.DestinationTableName = target;
                    _sqlConnection.Open();

                    using (_sqlConnection) // .Open()
                    {
                        bc.WriteToServer(dt);
                    } // .Close()
                    return (int)ExitCode.Success;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (int)ExitCode.UnknownError;
            }
        }

        public DataTable ExecuteSelectQuery()
        {

            
        }
    }
}