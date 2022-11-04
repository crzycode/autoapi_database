using System.Diagnostics;

namespace autoapi_database.Models
{
    public class CreateProject
    {
        private static dynamic Fileread;
        private static bool checkifexist = true;
        public static dynamic checkprojectexist(string project)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\ProjectDetails"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\ProjectDetails");
                File.Create(Directory.GetCurrentDirectory() + @"\ProjectDetails\Project.json");
            }

            Fileread = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\ProjectDetails\Project.json").ToList();
            for (int i = 0; i < Fileread.Count; i++)
            {
                if (Fileread[i] == project)
                {
                    checkifexist = false;
                    return "Project Name is already Exist";
                }
            }
            if (checkifexist == true)
            {

                ParameterizedThreadStart gp = new ParameterizedThreadStart(GenerateProject);
                Thread generateproject_thread = new Thread(gp);
                generateproject_thread.Priority = ThreadPriority.Highest;
                generateproject_thread.Start(project);
                generateproject_thread.Join();
                ParameterizedThreadStart efp = new ParameterizedThreadStart(EntityFrameworkpack);
                Thread EntityFramework_thread= new Thread(efp);
                EntityFramework_thread.Start(project);
                ParameterizedThreadStart fh = new ParameterizedThreadStart(FileHandles);
                Thread FileHandles_thread = new Thread(fh);
                FileHandles_thread.Start(project);
                ParameterizedThreadStart pu = new ParameterizedThreadStart(projectupdate);
                Thread projectupdate_thread = new Thread(pu);
                projectupdate_thread.Start(project);
            }
            stopwatch.Stop();
            return $"{stopwatch.Elapsed}";
        }

        private static void GenerateProject(object project)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.StandardInput.WriteLine(@"cd /d D:\Demos");
            p.StandardInput.WriteLine($@"dotnet new webapi --name {project}");
            p.StandardInput.Flush();
            p.StandardInput.Close();
            p.WaitForExit();
            p.Close();

        }
        private static void EntityFrameworkpack(object project)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.StandardInput.WriteLine($@"cd /d D:\Demos\{project}");
            p.StandardInput.WriteLine($@"dotnet add package Microsoft.EntityFrameworkCore --version 6.0.10");
            p.StandardInput.WriteLine($@"dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.10");
            p.StandardInput.Flush();
            p.StandardInput.Close();
            p.WaitForExit();
            p.Close();

        }

        private static void FileHandles(object project)
        {
            File.Delete($@"D:\Demos\{project}\WeatherForecast.cs");
            File.Delete($@"D:\Demos\{project}\Controllers\WeatherForecastController.cs");
            Directory.CreateDirectory($@"D:\Demos\{project}\Models");
            Directory.CreateDirectory($@"D:\Demos\{project}\DataContext");
            Directory.CreateDirectory($@"D:\Demos\{project}\Functions");
            Directory.CreateDirectory($@"D:\Demos\{project}\ConnectionStrings");

        }

        private static void projectupdate(object project)
        {
            Fileread.Insert(0, $"{project}");
            File.WriteAllLines(Directory.GetCurrentDirectory() + @"\ProjectDetails\Project.json", Fileread);
        }



    }
}
