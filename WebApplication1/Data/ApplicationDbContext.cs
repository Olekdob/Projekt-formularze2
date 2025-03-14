using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }



        public DbSet<Schronisko> Schroniska { get; set; }
        public DbSet<OcenaSchroniska> OcenySchroniska { get; set; }



        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    foreach (var entityType in builder.Model.GetEntityTypes())
        //    {
        //        foreach (var property in entityType.GetProperties())
        //        {
        //            if (property.ClrType == typeof(bool))
        //            {
        //                property.SetValueConverter(new BoolToZeroOneConverter<Int16>());
        //            }
        //        }
        //    }
        //}

    }


}
