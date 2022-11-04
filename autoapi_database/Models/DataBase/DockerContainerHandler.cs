using System.Diagnostics;

namespace autoapi_database.Models.DataBase
{
    public partial class DBCreate
    {
        private static void DockerContainerHandler()
        {

            Process p = new Process();
            p.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.StandardInput.WriteLine($@"docker run -e " + "ACCEPT_EULA=Y" + " -e " + "MSSQL_SA_PASSWORD=Mangal@123" + " -e " + "MSSQL_PID=Express" + $" -p {Ip}:{Port}:1433 --name Docker{DockerName}  --hostname Docker{DockerName} -d mcr.microsoft.com/mssql/server:2019-latest");
            p.StandardInput.WriteLine(@"docker ps -aqf" +$"name={DockerName}");
            p.StandardInput.Flush();
            p.StandardInput.Close();
            p.WaitForExit();
            string output = p.StandardOutput.ReadToEnd();
            p.Close();
            Message.AddLast("Sql Server Succesfully Installed ");
        }
    }
}
