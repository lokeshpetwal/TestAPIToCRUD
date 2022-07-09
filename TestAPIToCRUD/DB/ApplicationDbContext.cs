using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPIToCRUD.Models;

namespace TestAPIToCRUD.DB
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<EmployeeModel> Employee { set; get; }
        public DbSet<LogInModel> LogIn { set; get; }
    }
}
