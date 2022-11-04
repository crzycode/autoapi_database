
using autoapi_database.Models.IdGenerate;
using autoapi_database.Models.Logics;
using autoapi_database.Models.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace autoapi_database.Models.DataBase
{
    public partial class DBCreate
    {
        public static string Ip = Networks.GetRandomIpAddress();
        public static int Port = Networks.GetRandomPort();
        public static int DockerName = GenerateDockerId();
        
        public static bool checkifexist = true;
        public static LinkedList<string> Message = new LinkedList<string>();
       
        public static LinkedList<string>  GenerateDatabse(string database)
        {
            
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\DataBaseDetails"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\DataBaseDetails");
                File.Create(Directory.GetCurrentDirectory() + @"\DataBaseDetails\DataBaseDetails.json").Dispose();
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\DataBaseDetails\DataBaseDetails.json", "[\n]");
            }
            InsertUpdateActivity.InsertUpdate(0);
            string Fileread = File.ReadAllText(Directory.GetCurrentDirectory() + @"\DataBaseDetails\DataBaseDetails.json");

            var data  = JsonConvert.DeserializeObject<List<dynamic>>(Fileread);

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Username == database)
                {
                    checkifexist = false;
                    Message.AddLast($"User {data[i].Username} " + "Already Exist");
                    return Message;
                };
            }

            if(checkifexist == false)
            {
                DatabaseFileHandle(database);
                DockerContainerHandler();
            }
      

            return Message;
        }

      
    }
}
