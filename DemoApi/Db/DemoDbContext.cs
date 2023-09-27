using DemoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Db
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            var user = modelBuilder.Entity<User>();
            user.HasKey( x => x.Id);
            user.Property(p => p.FirstName).IsRequired();


            var address = modelBuilder.Entity<UserAddress>();
            address.HasKey( x => x.Id);

            address.HasOne(x => x.User)
                .WithOne(x => x.Address)
                .HasForeignKey<UserAddress>(fk =>fk.UserId);

        }
    }
}
