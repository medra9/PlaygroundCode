using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace wcfEdenred.DataAccess
{
    public class BaseData : IDisposable
    {
        private SqlConnection sqlConnection = null;
        public string connectionString { get; set; }
        public SqlTransaction ActiveTransaction  { get; set; }

        public BaseData()
        {
            try
            {
                connectionString = "Data Source=PCMAMA; User Id=sa; Password = 123; Initial Catalog=factura";
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        protected bool Connect()
        {
            var bolResult = false;
            if (this.sqlConnection != null && this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                return true;
            }
            try
            {
                if (this.sqlConnection == null)
                {
                    this.sqlConnection = new SqlConnection();
                    this.sqlConnection.ConnectionString = connectionString;
                }
                this.sqlConnection.Open();
                bolResult = true;
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                bolResult = false;
            }
            return bolResult;
        }

        protected SqlCommand CreateCommand()
        {
            var command = this.sqlConnection.CreateCommand();
            if (this.ActiveTransaction != null)
            {
                command.Transaction = this.ActiveTransaction;
            }
            return command;
        }

        public void Dispose()
        {
            if (this.sqlConnection != null)
            {
                if (this.ActiveTransaction != null)
                {
                    this.ActiveTransaction.Dispose();
                }
                this.sqlConnection.Close();
                this.sqlConnection.Dispose();
            }
            GC.Collect();
        }
    }
}