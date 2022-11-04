namespace autoapi_database.Models.Logics
{
    public class InsertUpdateActivity
    {
        public static void InsertUpdate(int point)
        {
            if(point == 0)
            {
                var Fileread = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\DataBaseDetails\DataBaseDetails.json").ToList();
                Fileread.RemoveAt(1);
                Fileread.Insert(1, "{");
                File.WriteAllLines(Directory.GetCurrentDirectory() + @"\DataBaseDetails\DataBaseDetails.json", Fileread);
            }
            if(point == 1)
            {
                var Fileread = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\DataBaseDetails\DataBaseDetails.json").ToList();
                Fileread.RemoveAt(1);
                Fileread.Insert(1, ",{");
                File.WriteAllLines(Directory.GetCurrentDirectory() + @"\DataBaseDetails\DataBaseDetails.json", Fileread);
            }
        }
    }
}
