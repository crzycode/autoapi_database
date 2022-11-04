using autoapi_database.Models.DataBase;
using System.Text.RegularExpressions;

namespace autoapi_database.Models
{
    public class CheckCode
    {
        



       


        public static string methodtype;
        public static string ProjectOrDatabase;
        public static string Database;
        public static dynamic CheckCodeIsValid(string code)
        {
            string Projects = "Create Project(ProjectName DataBaseName)";
                
            string[] Names = code.Split(new char[] { ' ', '(', ')' });
            var data= Names.ToList();
            List<string> CheckCode = new List<string>();
            
            for (int i = 0; i < data.Count; i++)
            {
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                data[i] = regex.Replace(data[i], " ");
                if (data[i].Length != 0)
                {
                    
                    if (i <= 1)
                    {
                        string upper = data[i].ToUpper();
                        CheckCode.Add(upper);
                    }
                    else
                    {
                        CheckCode.Add(data[i]);
                    }
                    
                    
                }
            }
            
            
            if (CheckCode[0] == "CREATE")
            {
                
                if (CheckCode[1] == "DATABASE")
                {
                    if (CheckCode.Count == 3)
                    {
                       LinkedList<string> Message = DBCreate.GenerateDatabse(CheckCode[2]);
                        
                    }
                    else
                    {
                       

                    }
                }
                if (CheckCode[1] == "PROJECT")
                {
                    if (CheckCode.Count >= 3)
                    {
                        CreateProject.checkprojectexist(CheckCode[2]);
                       
                    }
                    else
                    {
                      
                    }
                    if (CheckCode.Count == 4)
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
            }
            
           

            return "g";
        }
    }
}
