using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerStats.Data
{
    public class WorkerStats
    {
        public string Username { get; set; }
        public string AverageSecondsElapsed { get; set; }
        public string Count { get; set; }
        public string InWorker { get; set; }
        public string TimeSpent { get; set; }

        public WorkerStats(string username, string averageSecondsElapsed, string count, string inWorker, string timeSpent)
        {
            Username = username;
            AverageSecondsElapsed = averageSecondsElapsed;
            Count = count;
            InWorker = inWorker;
            TimeSpent = timeSpent;
        }

        public WorkerStats(string inWorker, string count)
        {
            InWorker = inWorker;
            Count = count;
        }
    }
}
