using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WorkerStats.Data
{
    public class ConnectToDatabase
    {
        //SQL database connection
        public string connectionString_SQL;
        const string testDataSource = "AMCDB04-T";
        const string productionDataSource = "AMCDB03";
        const string testInitialCatalog = "DevelopmentTesting";
        const string productionInitialCatalog = "";
        const string integratedSecurity = "True";
        const string multipleActiveResultSets = "True";
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;

        public string GetConnectionSQL()
        {
            //Connection for test database
            string connectionString_SQL = $"Data Source={testDataSource};Initial Catalog={testInitialCatalog};Integrated Security={integratedSecurity};MultipleActiveResultSets={multipleActiveResultSets};";
            //Connection for production database
            //string connectionString_SQL = $"Data Source={productionDataSource};Initial Catalog={productionInitialCatalog};Integrated Security={integratedSecurity};MultipleActiveResultSets={multipleActiveResultSets};";
            return connectionString_SQL;
        }

        //make sure to close connection and dispose the object
        public static void Dispose(SqlConnection con)
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            con.Dispose();
        }
    }
}
