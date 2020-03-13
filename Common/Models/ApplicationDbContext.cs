using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasQueryFilter(eb => eb.Active == true);

            builder.Entity<Customer>()
                .HasIndex(p => p.Passport)
                .IsUnique();
            //Seed
            //builder.Entity<Usuario>().HasData(
            //    new Usuario() 
            //    {
            //    },
            //    new Usuario()
            //    {
            //    });

        }

        #region Borrado Suave en SaveChanges y SaveChangesAsync
        public override int SaveChanges()
        {
            //Borrado Suave
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted &&
                e.Metadata.GetProperties().Any(x => x.Name == "Active")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["Active"] = false;
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //Borrado Suave
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted &&
                e.Metadata.GetProperties().Any(x => x.Name == "Active")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["Active"] = false;
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        #endregion

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
    }
}
