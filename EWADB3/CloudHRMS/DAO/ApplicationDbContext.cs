using CloudHRMS.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.DAO
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> db):base(db)
        {
           
        }
        //register the Employee Entity to the db set to know with database relation.
        public DbSet<EmployeeEntity>  Employees { get; set; }
    }
}
