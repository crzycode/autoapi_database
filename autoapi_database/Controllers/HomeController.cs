using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using autoapi_database.Data;
using System.Diagnostics;
using System.Management.Automation;
using autoapi_database.Models;
using autoapi_database.Models.DataBase;

namespace autoapi_database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DataContext db;
        public HomeController(DataContext _db)
        {
            this.db = _db;
        }
        [HttpPost]
        public dynamic createproject(string database)
        {
            /* LinkedList<string> data = CheckCode.CheckCodeIsValid(database);*/
            /*   CheckCode.CheckCodeIsValid(database);*/
            DBCreate.GenerateDatabse(database);
            return "string";
        }
        [HttpPost]
        [Route("createdatabase")]
        public string createdatabase(string database)
        {


            return "";
        }
    }
}
