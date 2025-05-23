using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<LoanStatus> LoanStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Loan>()
                .Property(l => l.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserId)
                .IsRequired();

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.LoanStatus)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.LoanStatusId)
                .IsRequired();
        }
    }
}
