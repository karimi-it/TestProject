using contactPresentation.Filters;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);
// Add services to the container.
builder.Services.AddControllersWithViews();
//var logger = new LoggerConfiguration()
//  .ReadFrom.Configuration(builder.Configuration)
//  .Enrich.FromLogContext()
//  .Filter.ByExcluding(c => c.Properties.Any(p => p.Value.ToString().Contains("swagger")))
  //.CreateLogger();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseSwagger();
//app.UseSwaggerUI();
app.UseRouting();
 
app.UseAuthorization();
app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
void ConfigureServices(IServiceCollection services)
{
    services.AddMediatR(Assembly.GetExecutingAssembly());
    services.AddDbContext<MyDbContext>(options =>
                    options.UseSqlServer(
                      builder.Configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(MyDbContext).Assembly.FullName)));
    //services.AddSwaggerGen();

    //services.AddSwaggerGen(c =>
    //{
    //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test Service API", Version = "v1" }); 

    //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //    c.IncludeXmlComments(xmlPath);
    //});

    /*services.AddDbContext<MyDbContext>(options =>
                     options.UseSqlServer(
                         Configuration.GetConnectionString("DefaultConnection"),
                         b => b.MigrationsAssembly(typeof(MyDbContext).Assembly.FullName)));*/
}
