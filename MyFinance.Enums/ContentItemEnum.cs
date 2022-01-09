using System;
using System.IO;
using System.Reflection;

namespace MyFinance.Enums
{
    public enum ContentItemEnum : short
    {
        Summary,
        Passbook,
        Predict,
        TransactionParty,
        Transaction,
        ManageTransaction,
        ManageScheduleTransaction,
        Task,
        ManageTask,
        LogAlert,
        Reports,
        Logs
    }

    public enum ContentRepeatItemEnum : short
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public enum ContentTaskTypesEnum : short
    {
        Appointment,       //-1
        Task              //-2
    }

    public enum ContentReportsTypesEnum : short
    {
        Transactions,
        Tasks

    }

    public class ApplicationErrorLog
    {
        public void ErrorLog(string Type, string Action, string Error)
        {
            string errorpath = "";

            try
            {
                string subPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ @"\ErrorLog"; 
                bool exists = System.IO.Directory.Exists(subPath);

                if (!exists)
                    System.IO.Directory.CreateDirectory(subPath);
                subPath += @"\Error_Log.txt";

                if (!File.Exists(subPath))
                {
                    FileStream fs = File.Create(subPath);
                    fs.Close();
                }

                string appendText = DateTime.Now.ToString("yyyy-MM-dd_hh:MM:ss")+"_"+ Type + "_"+Action+"_"+Error+"\n";
                File.AppendAllText(subPath, appendText);

                errorpath = subPath;
            }
            catch (Exception k)
            {
                File.AppendAllText(errorpath, DateTime.Now.ToString("dd/MM/yyyy") + "-Error in file writing\n");
            }
        }

    }
  
}
