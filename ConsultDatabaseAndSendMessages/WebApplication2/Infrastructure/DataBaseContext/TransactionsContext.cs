

using DatabaseApi.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DatabaseApi.Infrastructure.DataBaseContext
{
    public class TransactionsContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Entry> Entrys { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Telephone> Telephone { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(Environment.GetEnvironmentVariable("CONECTION_STRING"));

        public TransactionsContext(DbContextOptions<TransactionsContext> options): base(options)

        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>(entity => {
                entity.HasDiscriminator<string>("PeopleType")
                      .HasValue<People>("People")
                      .HasValue<Customer>("Customer");

                entity.HasKey(k => k.Id);

                entity.HasMany(k => k.Address)
                      .WithOne(k => k.People)
                      .HasForeignKey(k => k.PeopleId);

                entity.HasMany(k => k.Telephone)
                      .WithOne(k => k.People)
                      .HasForeignKey(k => k.PeopleId);
            });
            modelBuilder.Entity<Customer>(entity => {
                entity.HasMany(k => k.Account)
                      .WithOne(k => k.Holder)
                      .HasForeignKey(k => k.CustomerNumber);
            });

            modelBuilder.Entity<Account>(entity => {
                entity.HasKey(k => k.Id);

                entity.HasMany(k => k.Entrys)
                      .WithOne(k => k.Account)
                      .HasForeignKey(k => k.CustomerNumber);
            });
            modelBuilder.Entity<Address>(entity => {
                entity.HasKey(k => k.Id);

                entity.HasOne(k => k.People)
                      .WithMany(k => k.Address)
                      .HasForeignKey(k => k.PeopleId);

            });
            
            modelBuilder.Entity<Entry>(entity => {
                entity.HasKey(k => k.Id);

                entity.HasOne(k => k.Account)
                      .WithMany(k => k.Entrys)
                      .HasForeignKey(k => k.CustomerNumber);
            });
            
            modelBuilder.Entity<Telephone>(entity => {
                entity.HasKey(k => k.Id);

                entity.HasOne(k => k.People)
                      .WithMany(k => k.Telephone)
                      .HasForeignKey(k => k.PeopleId);
            });
        }
    }
}
