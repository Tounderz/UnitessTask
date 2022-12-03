using Microsoft.EntityFrameworkCore;
using UnitessLibrary.Models;

namespace UnitessTask.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
