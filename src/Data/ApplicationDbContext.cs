using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Models;

namespace PersonalExpenseTracker.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Expense> Expenses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Change identity table names
        modelBuilder.Entity<ApplicationUser>(x => x.ToTable("User"));
        modelBuilder.Entity<ApplicationRole>(x => x.ToTable("Role"));
        modelBuilder.Entity<IdentityUserClaim<Guid>>(x => x.ToTable("UserClaim"));
        modelBuilder.Entity<IdentityUserLogin<Guid>>(x => x.ToTable("UserLogin"));
        modelBuilder.Entity<IdentityUserToken<Guid>>(x => x.ToTable("UserToken"));
        modelBuilder.Entity<IdentityRoleClaim<Guid>>(x => x.ToTable("RoleClaim"));
        modelBuilder.Entity<IdentityUserRole<Guid>>(x => x.ToTable("UserRole"));

        modelBuilder.Entity<Category>(x => x.ToTable("Category"));
        modelBuilder.Entity<Expense>(x => x.ToTable("Expense"));

        modelBuilder.Entity<Expense>()
            .Property(x => x.Remark)
            .IsRequired(false);
    }
}
