using autoapi_database.Models.IdGenerate;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace autoapi_database.Models.DataBase
{
    public partial class DBCreate
    {
        private static void DatabaseFileHandle(string database)
        {
            var readdata = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\DataBaseDetails\DataBaseDetails.json").ToList();
            if (checkifexist == true)
            {

               /* dynamic record = new
                {
                    UserId = "",
                    Username = "",
                    Network  = new {
                    IpAddress ="",
                    Port = ""
                    },
                   


                };*/
                dynamic product = new JObject();
                product.UserId = UserId.GetRandomUserId();
                product.Username = "Elbow Grease";
                product.Network = new JArray(Ip, Port);
                product.Container = new JArray(new JObject(new JProperty("Dockername", $"{DockerName}")));
                product.SqlServer = new JObject();
                product.SqlServer.Add("ServerName", $"{Ip},{Port}");
                product.ConectionString = new JArray(new JObject(
                    new JProperty("connection2", $"Data Source={Ip},{Port};Initial Catalog={database};User ID=sa;Password=Mangal@123")
                    ));
                var json = JsonConvert.SerializeObject(product, Formatting.Indented);
                readdata.Insert(1, "," + json);
                File.WriteAllLines(Directory.GetCurrentDirectory() + @"\DataBaseDetails\DataBaseDetails.json", readdata);
                Message.AddLast($"{ Ip}:{Port}");
                Message.AddLast($"{DockerName}");
            }

        }
    }
}
