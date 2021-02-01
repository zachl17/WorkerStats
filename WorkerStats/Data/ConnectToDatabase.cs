using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Odbc;

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


        //MySQL database connection
        public string connectionString_MySQL;
        public static string mysqlDriver = "{MYSQL ODBC 5.1 Driver}";
        public static string mysqlServer = "amc-mysql.americollect.com";
        public OdbcConnection mySQLConnection;
        public OdbcCommand mySQLCommand;

        public string GetConnectionSQL()
        {
            //Connection for test database
            string connectionString_SQL = $"Data Source={testDataSource};Initial Catalog={testInitialCatalog};Integrated Security={integratedSecurity};MultipleActiveResultSets={multipleActiveResultSets};";
            //Connection for production database
            //string connectionString_SQL = $"Data Source={productionDataSource};Initial Catalog={productionInitialCatalog};Integrated Security={integratedSecurity};MultipleActiveResultSets={multipleActiveResultSets};";
            return connectionString_SQL;
        }

        public string GetConnectionMySQL()
        {
            connectionString_MySQL = $"Driver={mysqlDriver}; Server={mysqlServer}; uid=ScoreRevamp; pwd=g8jgjeBWtjweEoYe; db=ScoreRevamp;";
            //connectionString_MySQL = $"Driver={mysqlDriver};Server={mysqlServer};uid=ScoreRevamp;pwd=g8jgjeBWtjweEoYe;db=ScoreRevamp;";
            //connectionString_MySQL = $"DRIVER={mysqlDriver};Server={mysqlServer};Database=AllWorkerStats;USER=nawworker;PASSWORD=facet1566;Option=3;";

            return connectionString_MySQL;
        }

        //make sure to close connection and dispose the object
        public static void Dispose(SqlConnection con)
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            con.Dispose();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
