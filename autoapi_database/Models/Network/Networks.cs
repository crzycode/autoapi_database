namespace autoapi_database.Models.Network
{

    public class Networks
    {
        
       
        
         public static string GetRandomIpAddress()
        {
            var random = new Random();
            string IP = $"{random.Next(127, 127)}.{random.Next(0, 254)}.{random.Next(0, 254)}.{random.Next(0, 254)}";

            return IP; ;
        }
        public static int GetRandomPort()
        {
            var random = new Random();

            return random.Next(20, 65534); ;
        }
    }
}
