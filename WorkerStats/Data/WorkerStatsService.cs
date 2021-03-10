using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WorkerStats.Data
{
    public class WorkerStatsService
    {
        //used for MS SQL connection
        private SqlConnection cnSQL;

        private SqlCommand selectCMD;
        private SqlDataReader drSQL;
        public string connectionStringSQL;
        private static string allWorkersTable = "[dbo].[AllWorkers.Workers]";
        private static string allWorkerStatsTable = "[dbo].[AllWorkers.WorkerStats]";

        //used for queries
        public static string inWorker;

        public static string uniqueUserToSearch;
        public static string startDate;
        public static string endDate;

        //lists to store sql results
        private List<WorkerStats> workerStatsList = new List<WorkerStats>();

        private List<WorkerStats> remainingWorkerStatsTotals = new List<WorkerStats>();

        //Monitored stats for each department to used in the in statement
        //    private static string arMonitoredStats = @"('DCSCRUB','P6H', 'DWL', 'EMLV', 'FINDEMP', 'NAW', 'M', 'P', 'SHARED', '2. Kids', '2. Kids Help', 'MERCY_MAIL', 'DNNO',
        //'Scrub Returned Positive Result', 'Banko Multi Type', 'NCD', 'PBT', 'PBS', 'PNC_Worker','7','CH7MEETING', 'CH7NOTICES', 'CH13MEETING', 'CH13NOTICES', 'CFR', 'TPO', 'Minor_Worker',
        //'No_Nos_QR', 'CQC: 2K', 'CQC: BK', 'CQC: CD', 'CQC: CS', 'CQC: INS', 'CQC: LG', 'Super_Deduper', 'DUPE_LISTED', 'SSN_DOB', 'ADNC', 'Vidant System Generated',
        //'JohnDoe', 'Interest_Rate_Notice_Issues', 'AURORA_DECEASED_CLOSED', 'Aurora_Experian_Deceased', 'CRC_Daily', 'NAPCP', 'Need_More_Pmts', 'CT_Phone_Valid', 'No_Ntc_Send', 'LGH_Worker')";

        private static string arMonitoredStats = @"('P6H', 'FINDEMP', 'SHARED', 'DNNO', 'SSN_DOB', 'EMLV', 'DWL', 'TPO', 'BANKO_MULTI_TYPE', 'MERCY_MAIL', 'CFR', 'NCD', 'PBS', 'PBT',
    'AURORA_EXPERIAN_DECEASED', 'AURORA_DECEASED_CLOSED', 'DUPE_LISTED', 'PNC', 'MINOR', 'SUPER_DEDUPER', 'SPANISH_CALL_MONITOR', 'NEED_MORE_PMTS', 'NEED_MORE_PMTS_Y_WINDOW', 'NO_NOS_QR',
    'DC_SCRUB', 'CR_DAILY', 'JOHN_DOE', 'INTEREST_RATE_NOTICE_ISSUES', 'MOVE_ACCOUNTS', 'CT_PHONE_VALID')";

        private static string legalMonitoredStats = @"('2KD', 'EMLV_LEGAL')";

        private static List<string> arTables = new List<string> { @"[dbo].[AllWorkers.EMLV_Data]", "[dbo].[AllWorkers.FindEmpWorker]", "[dbo].[AllWorkers.P6HWorker]", "[dbo].[AllWorkers.MercyMailData]",
            "[dbo].[AllWorkers.DNNO_Data]", "[dbo].[AllWorkers.AuroraDeceased_ClosedData]", "[dbo].[AllWorkers.CFRemoval_Data]", "[dbo].[AllWorkers.DeceasedNCD]", "[dbo].[AllWorkers.MinorWorker_BaseDebtor]",
            "[dbo].[AllWorkers.DeceasedPBS]", "[dbo].[AllWorkers.DeceasedPBT]", "[dbo].[AllWorkers.BankoMultiData]", "[dbo].[AllWorkers.DupeListedCheck_Data]", "[dbo].[AllWorkers.DWL_Data]",
            "[dbo].[AllWorkers.NeedMorePmts_Data]", "[dbo].[AllWorkers.NeedMorePmts_Y_Setup]", "[dbo].[AllWorkers.PhoneDedupe_Phone]", "[dbo].[TPO_Phone_Own.Worker]", "[dbo].[AllWorkers.NoNos_Data]",
            "[dbo].[AllWorkers.DCScrub_Data]", "[dbo].[AllWorkers.CRCDaily_Data]", "[dbo].[AllWorkers.JohnDoe_Data]", "[dbo].[AllWorkers.InterestRateNoticeIssues_Data]", "[dbo].[AllWorkers.MoveAccounts_Data]",
            "[dbo].[AllWorkers.CTPhoneValid_Data]"};

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
                    WHERE CONVERT(DATE, EndDateTime) >= GETDATE() -1
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
                                WHERE CONVERT(DATE, EndDateTime) >= GETDATE() -1
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
                                WHERE CONVERT(DATE, EndDateTime) >= GETDATE() -1
                                AND Username = '{user}'
                                ) AS a GROUP BY Username, InWorker
                                ORDER BY InWorker, COUNT(*) DESC";
            }
            //if startdate & endate is today, user is null, worker is null
            else if (startDate == DateTime.Today.ToString("yyyy-MM-dd") && endDate == DateTime.Today.ToString("yyyy-MM-dd") && String.IsNullOrEmpty(user) && String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE CONVERT(DATE, EndDateTime) >= GETDATE() -1
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
                                WHERE CONVERT(DATE, EndDateTime) >= GETDATE() -1
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
            //if startdate is not today, endate is today, user is null, worker is null
            else if (startDate != DateTime.Today.ToString("yyyy-MM-dd") && endDate == DateTime.Today.ToString("yyyy-MM-dd") && String.IsNullOrEmpty(user) && String.IsNullOrEmpty(inWorker))
            {
                searchSelectSQL = @$"SELECT Username, ROUND(AVG(SecondsElapsed),2) AS 'AVG', COUNT(*) AS 'Count', InWorker, SUM(SecondsElapsed) AS 'TimeSpent'
                                FROM(
                                SELECT *
                                FROM {allWorkerStatsTable}
                                WHERE EndDateTime BETWEEN '{startDate} 00:00:00.001' AND '{endDate} 23:59:59.999'
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

        public void WriteExcelFile(List<WorkerStats> workerStats, string start, string end, string user, string worker)
        {
            // Lets converts our object data to Datatable for a simplified logic.
            // Datatable is most easy way to deal with complex datatypes for easy reading and formatting.
            DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(workerStats), (typeof(DataTable)));

            string timeStamp = DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss");

            using (SpreadsheetDocument document = SpreadsheetDocument.Create($@"G:\\Instructions\\Visual_Studio\\ZachL\\TestOutput\\{timeStamp}_TestData.xlsx", SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = $"{user}_Export"};

                sheets.Append(sheet);

                Row headerRow = new Row();

                List<String> columns = new List<string>();
                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(column.ColumnName);
                    headerRow.AppendChild(cell);
                }

                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in table.Rows)
                {
                    Row newRow = new Row();
                    foreach (String col in columns)
                    {
                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(dsrow[col].ToString());
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }

                workbookPart.Workbook.Save();
            }
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