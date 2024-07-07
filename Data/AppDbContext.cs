using Api_2._0;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api_2;

public class AppDbContext : IdentityDbContext<User>{
    public AppDbContext(DbContextOptions<AppDbContext> appDbContext) : base(appDbContext)
    {
        
    }
    public DbSet<Employee> Employees { get; set; }
}