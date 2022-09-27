using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Education.Entities;
using Microsoft.EntityFrameworkCore;

namespace Education.Data;
public class AppDbContext : IdentityDbContext
{
    public DbSet<Student>? Students {get; set;}
    public DbSet<Course>? Courses {get; set;}
    public DbSet<Teacher>? Teachers {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options){}
    
}