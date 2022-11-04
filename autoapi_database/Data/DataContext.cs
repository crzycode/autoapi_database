
using Microsoft.EntityFrameworkCore;

namespace autoapi_database.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }
       

    }
}
