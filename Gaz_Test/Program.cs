using Domain.Abstraction;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.DataBase;
using Persistence.DataBase.DataBaseRepositoryes;
using Service.Implementations;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IReposiroryBase<Employee, Guid>, EmployeeRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
