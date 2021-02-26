using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerStats.Data
{
    public class WorkerStatsService
    {
        //used for MS SQL connection
        SqlConnection cnSQL;
        SqlCommand selectCMD;
        SqlDataReader drSQL;
        public string connectionStringSQL;
        private static string allWorkersTable = "[dbo].[AllWorkers.Workers]";
        private static string allWorkerStatsTable = "[dbo].[AllWorkers.WorkerStats]";

        //used for queries
        public static string inWorker;
        public static string uniqueUserToSearch;
        public static string startDate;
        public static string endDate;

        //lists to store sql results
        List<WorkerStats> workerStatsList = new List<WorkerStats>();
        List<WorkerStats> remainingWorkerStatsTotals = new List<WorkerStats>();

        //Monitored stats for each department to used in the in statement
        //    private static string arMonitoredStats = @"('DCSCRUB','P6H', 'DWL', 'EMLV', 'FINDEMP', 'NAW', 'M', 'P', 'SHARED', '2. Kids', '2. Kids Help', 'MERCY_MAIL', 'DNNO', 
        //'Scrub Returned Positive Result', 'Banko Multi Type', 'NCD', 'PBT', 'PBS', 'PNC_Worker','7','CH7MEETING', 'CH7NOTICES', 'CH13MEETING', 'CH13NOTICES', 'CFR', 'TPO', 'Minor_Worker', 
        //'No_Nos_QR', 'CQC: 2K', 'CQC: BK', 'CQC: CD', 'CQC: CS', 'CQC: INS', 'CQC: LG', 'Super_Deduper', 'DUPE_LISTED', 'SSN_DOB', 'ADNC', 'Vidant System Generated', 
        //'JohnDoe', 'Interest_Rate_Notice_Issues', 'AURORA_DECEASED_CLOSED', 'Aurora_Experian_Deceased', 'CRC_Daily', 'NAPCP', 'Need_More_Pmts', 'CT_Phone_Valid', 'No_Ntc_Send', 'LGH_Worker')";

        private static string arMonitoredStats = @"('P6H', 'FINDEMP', '2KD', 'SHARED', 'DNNO', 'SSN_DOB', 'EMLV', 'DWL', 'TPO', 'BANKO_MULTI_TYPE', 'MERCY_MAIL', 'CFR', 'NCD', 'PBS', 'PBT',
    'AURORA_EXPERIAN_DECEASED', 'AURORA_DECEASED_CLOSED', 'DUPE_LISTED', 'PNC', 'MINOR', 'SUPER_DEDUPER', 'SPANISH_CALL_MONITOR', 'NEED_MORE_PMTS', 'NEED_MORE_PMTS_Y_WINDOW', 'NO_NOS_QR',
    'DC_SCRUB')";

        private static string legalMonitoredStats = @"('2KD', 'EMLV_LEGAL')";

        private static List<string> arTables = new List<string> { @"[dbo].[AllWorkers.EMLV_Data]", "[dbo].[AllWorkers.FindEmpWorker]", "[dbo].[AllWorkers.P6HWorker]", "[dbo].[AllWorkers.MercyMailData]",
            "[dbo].[AllWorkers.DNNO_Data]", "[dbo].[AllWorkers.AuroraDeceased_ClosedData]", "[dbo].[AllWorkers.CFRemoval_Data]", "[dbo].[AllWorkers.DeceasedNCD]", "[dbo].[AllWorkers.MinorWorker_BaseDebtor]",
            "[dbo].[AllWorkers.DeceasedPBS]", "[dbo].[AllWorkers.DeceasedPBT]", "[dbo].[AllWorkers.BankoMultiData]", "[dbo].[AllWorkers.DupeListedCheck_Data]", "[dbo].[AllWorkers.DWL_Data]",
            "[dbo].[AllWorkers.NeedMorePmts_Data]", "[dbo].[AllWorkers.NeedMorePmts_Y_Setup]", "[dbo].[AllWorkers.PhoneDedupe_Phone]", "[dbo].[TPO_Phone_Own.Worker]", "[dbo].[AllWorkers.NoNos_Data]",
            "[dbo].[AllWorkers.DCScrub_Data]"};

        private static List<string> legalTables = new List<string> { "[dbo].[AllWorkers.2KDFacebookWorker]", "[dbo].[AllWorkers.EMLV_LegalRevamp]" };

        //Get todays stats for specified dept
        public Task<List<WorkerStats>> GetStatsAsync(string department)
        {
            string monitoredStats = "";

            //determine which monitored stats to use based on dept
            switch (department)
            {
                case "AccountReviewPage":
                    monitoredStats = arMonitoredStats;
                    break;
                case "LegalPage":
                    monitoredStats = legalMonitoredStats;
                    break;
                default:
                    break;
            }

            //clear list on component being initialized
            workerStatsList.Clear();
            connectionStringSQL = new ConnectToDatabase().GetConnectionSQL();
            //connectionStringSQL = new ConnectToDatabase().GetConnectionMySQL();

            string selectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker AS 'InWorker', SUM(SecondsElapsed) AS 'TimeSpent'
                    FROM(
                    SELECT *
                    FROM {allWorkerStatsTable}
                    WHERE CONVERT(DATE, EndDateTime) >= GETDATE() -500
                    AND InWorker IN {monitoredStats}
                    ) AS a GROUP BY Username, InWorker
                    ORDER BY InWorker, COUNT(*) DESC";

            using (cnSQL = new SqlConnection(connectionStringSQL))
            {
                cnSQL.Open();
                using (selectCMD = new SqlCommand(selectSQL, cnSQL))
                {
                    using (drSQL = selectCMD.ExecuteReader())
                    {
                        while (drSQL.Read())
                        {
                            workerStatsList.Add(new WorkerStats(drSQL["Username"].ToString(), convertSeconds(drSQL["AVG"].ToString()), drSQL["Count"].ToString(), drSQL["InWorker"].ToString(), convertSeconds(drSQL["TimeSpent"].ToString()), drSQL["TimeSpent"].ToString()));
                        }
                    }
                }
            }
            return Task.FromResult(workerStatsList);
        }

        //Queries tables related to dept to get total remaining #'s in workers
        public Task<List<WorkerStats>> GetRemainingTotalsAsync(string deptTables)
        {
            List<string> tablesToQuery = new List<string>();

            //Determine which monitored stats to use based on dept
            switch (deptTables)
            {
                case "AccountReviewPage":
                    tablesToQuery = arTables;
                    break;
                case "LegalPage":
                    tablesToQuery = legalTables;
                    break;
                default:
                    break;
            }

            remainingWorkerStatsTotals.Clear();
            connectionStringSQL = new ConnectToDatabase().GetConnectionSQL();

            using (cnSQL = new SqlConnection(connectionStringSQL))
            {
                cnSQL.Open();
                foreach (var table in tablesToQuery)
                {
                    string selectSQL = @$"SELECT InWorker AS 'InWorker', COUNT(*) AS 'Count' FROM {table} 
                            INNER JOIN {allWorkersTable}
                            ON {table}.WorkerID = {allWorkersTable}.WorkerID
                            GROUP BY InWorker
                            ORDER BY InWorker, COUNT(*) DESC";

                    using (selectCMD = new SqlCommand(selectSQL, cnSQL))
                    {
                        using (drSQL = selectCMD.ExecuteReader())
                        {
                            while (drSQL.Read())
                            {
                                remainingWorkerStatsTotals.Add(new WorkerStats(drSQL["InWorker"].ToString(), drSQL["Count"].ToString()));
                            }
                        }
                    }
                }
            }
            return Task.FromResult(remainingWorkerStatsTotals);
        }

        //Search based on form fields from razor component
        public Task<List<WorkerStats>> SearchResultsAsync(string start, string end, string user, string worker)
        {
            string searchSelectSQL = "";
            startDate = start;
            endDate = end;
            uniqueUserToSearch = user;
            inWorker = worker;

            //if startdate & endate is today and user and worker is null
            if (startDate == DateTime.Today.ToString("yyyy-MM-dd") && endDate == DateTime.Today.ToString("yyyy-MM-dd") && !String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE CONVERT(DATE, EndDateTime) >= GETDATE() -500
                                AND Username = '{user}'
                                AND InWorker IN ('{inWorker}')
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            //if startdate & endate is today, user is not null, worker is null
            else if (startDate == DateTime.Today.ToString("yyyy-MM-dd") && endDate == DateTime.Today.ToString("yyyy-MM-dd") && !String.IsNullOrEmpty(user) && String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE CONVERT(DATE, EndDateTime) >= GETDATE() -500
                                AND Username = '{user}'
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            //if startdate & endate is today, user is null, worker is not null
            else if (startDate == DateTime.Today.ToString("yyyy-MM-dd") && endDate == DateTime.Today.ToString("yyyy-MM-dd") && String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE CONVERT(DATE, EndDateTime) >= GETDATE() -500
                                 AND InWorker IN ('{inWorker}')
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            //if startdate is today, endate is not today, user is not null, worker is null
            else if (startDate == DateTime.Today.ToString("yyyy-MM-dd") && endDate != DateTime.Today.ToString("yyyy-MM-dd") && !String.IsNullOrEmpty(user) && String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE EndDateTime BETWEEN '{startDate} 00:00:00.001' AND '{endDate} 23:59:59.999'
                                AND Username = '{user}'
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            //if startdate is today, endate is not today, user is null, worker is not null
            else if (startDate == DateTime.Today.ToString("yyyy-MM-dd") && endDate != DateTime.Today.ToString("yyyy-MM-dd") && String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE EndDateTime BETWEEN '{startDate} 00:00:00.001' AND '{endDate} 23:59:59.999'
                                AND InWorker IN ('{inWorker}')
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            //if startdate is not today, endate is today, user is null, worker is not null
            else if (startDate != DateTime.Today.ToString("yyyy-MM-dd") && endDate == DateTime.Today.ToString("yyyy-MM-dd") && String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE EndDateTime BETWEEN '{startDate} 00:00:00.001' AND '{endDate} 23:59:59.999'
                                AND InWorker IN ('{inWorker}')
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            //if startdate is not today, endate is today, user is not null, worker is null
            else if (startDate != DateTime.Today.ToString("yyyy-MM-dd") && endDate == DateTime.Today.ToString("yyyy-MM-dd") && !String.IsNullOrEmpty(user) && String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE EndDateTime BETWEEN '{startDate} 00:00:00.001' AND '{endDate} 23:59:59.999'
                                AND Username = '{user}'
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            //if startdate & endate is not today, user & worker is null
            else if (startDate != DateTime.Today.ToString("yyyy-MM-dd") && endDate != DateTime.Today.ToString("yyyy-MM-dd") && String.IsNullOrEmpty(user) && String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE EndDateTime BETWEEN '{startDate} 00:00:00.001' AND '{endDate} 23:59:59.999'
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            //if startdate & endate is not today, user is not null, worker is null
            else if (startDate != DateTime.Today.ToString("yyyy-MM-dd") && endDate != DateTime.Today.ToString("yyyy-MM-dd") && !String.IsNullOrEmpty(user) && String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE EndDateTime BETWEEN '{startDate} 00:00:00.001' AND '{endDate} 23:59:59.999'
                                AND Username = '{user}'
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            //if startdate & endate is not today, user is null, worker is not null
            else if (startDate != DateTime.Today.ToString("yyyy-MM-dd") && endDate != DateTime.Today.ToString("yyyy-MM-dd") && String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE EndDateTime BETWEEN '{startDate} 00:00:00.001' AND '{endDate} 23:59:59.999'
                                AND InWorker IN ('{inWorker}')
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            else
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE EndDateTime BETWEEN '{startDate} 00:00:00.001' AND '{endDate} 23:59:59.999'
                                AND Username = '{user}'
                                AND InWorker IN ('{inWorker}')
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }

            workerStatsList.Clear();
            connectionStringSQL = new ConnectToDatabase().GetConnectionSQL();

            using (cnSQL = new SqlConnection(connectionStringSQL))
            {
                cnSQL.Open();
                using (selectCMD = new SqlCommand(searchSelectSQL, cnSQL))
                {
                    using (drSQL = selectCMD.ExecuteReader())
                    {
                        while (drSQL.Read())
                        {
                            workerStatsList.Add(new WorkerStats(drSQL["Username"].ToString(), convertSeconds(drSQL["AVG"].ToString()), drSQL["Count"].ToString(), drSQL["InWorker"].ToString(), convertSeconds(drSQL["TimeSpent"].ToString()), drSQL["TimeSpent"].ToString()));
                        }
                    }
                }
            }
            return Task.FromResult(workerStatsList);
        }


        //converts SecondsElapsed field from AllWorkerStats table into something more readable (EXAMPLE: 1 hours 13 minutes 48 seconds)
        public string convertSeconds(string secondsElapsed)
        {
            int secondsConvertedToInt = Convert.ToInt32(secondsElapsed);
            var timespan = TimeSpan.FromSeconds(secondsConvertedToInt);
            string finalSecondsConverted;

            if (timespan.TotalMinutes < 1.0) // less than 1 minute
            {
                finalSecondsConverted = String.Format("{0} Seconds", timespan.Seconds);
            }
            else if (timespan.TotalHours < 1.0) // less than 1 hour
            {
                finalSecondsConverted = String.Format("{0} Minutes {1:D2} Seconds", timespan.Minutes, timespan.Seconds);
            }
            else // more than 1 hour
            {
                finalSecondsConverted = String.Format("{0} Hours {1:D2} Minutes {2:D2} Seconds", (int)timespan.TotalHours, timespan.Minutes, timespan.Seconds);
            }
            return finalSecondsConverted;
        }
    }
}
