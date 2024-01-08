using Dynatron.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dynatron.DAL
{
  public class CustomerContext : DbContext
  {
    public CustomerContext(DbContextOptions<CustomerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Customer>().HasData(new Customer[]
          {
          new Customer{ Id = 1, FirstName = "Raouf", LastName = "Ali", CreatedDate = DateTime.Now.AddDays(-1), Email = "random@mail.com" },
          new Customer{ Id = 2, FirstName = "Narcissus", LastName = "Zander", CreatedDate = DateTime.Now.AddDays(-3), Email = "narci.zander@arvinmeritor.info" },
          new Customer{ Id = 3, FirstName = "Vyvyan", LastName = "Zuber", CreatedDate = DateTime.Now.AddDays(-1), Email = "vyvya_zuber@careful-organics.org" },
          new Customer{ Id = 4, FirstName = "Julya", LastName = "Kelton", CreatedDate = DateTime.Now.AddDays(-4), Email = "ju-kelto@consolidated-farm-research.net" },
          new Customer{ Id = 5, FirstName = "Aleksia", LastName = "Munos", CreatedDate = DateTime.Now.AddDays(-5), Email = "ale.mu@arketmay.com" },
          new Customer{ Id = 6, FirstName = "Lakshman", LastName = "Byrnes", CreatedDate = DateTime.Now.AddDays(-6), Email = "lakshmadono@autozone-inc.info" },
          new Customer{ Id = 7, FirstName = "Morgana", LastName = "Lenhart", CreatedDate = DateTime.Now.AddDays(-7), Email = "mo.munos@consolidated-farm-research.net" },
          new Customer{ Id = 8, FirstName = "Beatrice", LastName = "Eatmon", CreatedDate = DateTime.Now.AddDays(-7), Email = "bea-byrn@consolidated-farm-research.net" },
          new Customer{ Id = 9, FirstName = "Mindel", LastName = "", CreatedDate = DateTime.Now.AddDays(-20), Email = "minde.byrn@egl-inc.info" },
          new Customer{ Id = 10, FirstName = "Algerine", LastName = "Clymer", CreatedDate = DateTime.Now.AddDays(-1), Email = "algerin.lenhar@arvinmeritor.info" },
          new Customer{ Id = 11, FirstName = "Klementyna", LastName = "Marburger", CreatedDate = DateTime.Now.AddDays(-11), Email = "klementynaeatm@autozone-inc.info" },
          new Customer{ Id = 12, FirstName = "Varanese", LastName = "Clymer", CreatedDate = DateTime.Now.AddDays(-7), Email = "var_eatm@arvinmeritor.info" },
          new Customer{ Id = 13, FirstName = "Mairead", LastName = "Gerson", CreatedDate = DateTime.Now.AddDays(-9), Email = "ma_eat@acusage.net" },
          new Customer{ Id = 14, FirstName = "Melik", LastName = "Zander", CreatedDate = DateTime.Now.AddDays(-45), Email = "meli_cl@progressenergyinc.info" },
          new Customer{ Id = 15, FirstName = "Klementyna", LastName = "Womack", CreatedDate = DateTime.Now.AddDays(-6), Email = "Marburger,klementynmarburge@egl-inc.info" },
          new Customer{ Id = 16, FirstName = "Lakshman", LastName = "Zuber", CreatedDate = DateTime.Now.AddDays(-77), Email = "laksh-cly@consolidated-farm-research.net" },
          new Customer{ Id = 17, FirstName = "Sneha", LastName = "Donohue", CreatedDate = DateTime.Now.AddDays(-68), Email = "sn.gerso@diaperstack.com" },
          new Customer{ Id = 18, FirstName = "Marny", LastName = "Byrnes", CreatedDate = DateTime.Now.AddDays(-1), Email = "marny_zander@acusage.net" },
          new Customer{ Id = 19, FirstName = "Servan", LastName = "Lenhart", CreatedDate = DateTime.Now.AddDays(-2), Email = "servanza@arvinmeritor.info" },
          new Customer{ Id = 20, FirstName = "Cherish", LastName = "Eatmon", CreatedDate = DateTime.Now.AddDays(-555), Email = "cheriswomack@egl-inc.info" },
          new Customer{ Id = 21, FirstName = "Catalina", LastName = "Marburger", CreatedDate = DateTime.Now.AddDays(-365), Email = "marburg@careful-organics.org" },
          //add other customer..
          });
    }

    public DbSet<Customer> Customers { get; set; } = null!;
  }

}
