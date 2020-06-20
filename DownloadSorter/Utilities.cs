using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadSorter
{
    public class Utilities
    {
        public string ValidateATM(string processingCode, string responseCode, string adjustmentDate)
        {
            string action = string.Empty;
            List<string> actionToTake = new List<string>();
            if (processingCode.StartsWith("2"))
                actionToTake.Add("bounce");
            if (responseCode != "00")
                actionToTake.Add("bounce");
            if (!string.IsNullOrEmpty(adjustmentDate))
                actionToTake.Add("bounce");

            if (actionToTake.Contains("bounce"))
                action = "bounce";
            action = "allow";

            return action;
        }
        public string ValidatePOSandWEB(string processingCode, string responseCode, string adjustmentDate, string transType, string adviseReasonCode, string trace)
        {
            string action = string.Empty;
            List<string> actionToTake = new List<string>();
            if (processingCode.StartsWith("2"))
                actionToTake.Add("bounce");
            if (!responseCode.Equals("00"))
                actionToTake.Add("bounce");
            if (!string.IsNullOrEmpty(adjustmentDate))
                actionToTake.Add("bounce");
            if (!transType.ToUpper().Equals("C"))
                actionToTake.Add("bounce");
            if (!adviseReasonCode.Equals("290"))
                actionToTake.Add("bounce");
            if (!trace.Equals("999999"))
                actionToTake.Add("bounce");

            if (actionToTake.Contains("bounce"))
                action = "bounce";
            action = "allow";

            return action;
        }

        string actionToTake = utility.ValidateATM(string processingCode, string responseCode, string adjustmentDate);
        string actionToTake = utility.ValidatePOSandWEB(string processingCode, string responseCode, string adjustmentDate, string transType, string adviseReasonCode, string trace);
    }
}
