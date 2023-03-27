using RestAPI.Repository.IRepository;
using RestAPI.Repository;
using RestAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("CustomerDbConnectionString")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("CorsPolicy");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
