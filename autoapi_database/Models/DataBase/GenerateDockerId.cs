using System.Security.Cryptography;

namespace autoapi_database.Models.DataBase
{
    public partial class DBCreate
    {
        private static int GenerateDockerId()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[16];//4 for int32
                rng.GetBytes(randomNumber);
                int value = BitConverter.ToInt32(randomNumber, 0);
                return value;
            }
        }
    }
}
