using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EDI_DB.Data.Base;

namespace EDICommons.Tools
{
    public static class LogWriter
    {
        public static void WriteMessage(string EventSource, string Message)
        {
            //Write to application log
            //string EventSource = "EDI 850 Processor";
            // string Log = "Application";

            try
            {
                DB_RSS.LogData(Message);
                /*
                if (!EventLog.SourceExists(EventSource))
                    EventLog.CreateEventSource(EventSource, Log);

                EventLog.WriteEntry(EventSource, Message, EventLogEntryType.Error, 911); */
            }
            catch(Exception)
            {
                return;
            }

        }
    }
}
