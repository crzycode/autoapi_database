namespace autoapi_database.Models.IdGenerate
{
    public class UserId
    {
        public static int GetRandomUserId()
        {
            var random = new Random();

            return random.Next(1, 655355655); ;
        }
    }
}
