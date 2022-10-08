using Education;
using Education.Data;
using Education.Repositories;
using Education.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    
builder.Services.AddIdentity<IdentityUser,IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    
}).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>(); 

builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IStudentService,StudentService>();
builder.Services.AddTransient<ICourseService,CourseService>();
builder.Services.AddTransient<ITeacherService,TeacherService>();
builder.Services.AddTransient<ISeedService,SeedService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    
await Seed.InitializeRoleAsync(app);
await Seed.InitializeUserAsync(app);

app.Run();
