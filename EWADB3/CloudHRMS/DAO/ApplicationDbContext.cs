using CloudHRMS.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.DAO
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> db):base(db)
        {
           
        }
        //register the Employee Entity to the db set to know with database relation.
        public DbSet<EmployeeEntity>  Employees { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<PositionEntity> Positions { get; set; }
    }
}
