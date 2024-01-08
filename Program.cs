using Dynatron.DAL;
using Dynatron.Web.API.DAL;
using Dynatron.Web.API.Services.CustomerLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Dynatron.Web.API
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      builder.Services.AddControllers();
      builder.Services.AddDbContext<CustomerContext>(opt =>
          opt.UseInMemoryDatabase("CustomerDB"));
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      // Register interface and classes
      builder.Services.AddScoped<ICustomerLogic, CustomerLogic>();
      builder.Services.AddScoped<IDataRepository, DataRepository>();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        using (var scope = app.Services.CreateScope())
        {
          var dbContext = scope.ServiceProvider.GetRequiredService<CustomerContext>();
          dbContext.Database.EnsureCreated();
        }
        app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();


      app.Run();
    }

  }
}
