using Microsoft.EntityFrameworkCore;
namespace Web.Database;
using Web.Model;

public class  UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UserName> UserName { get; set; }
    // Otros DBsets

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define foreign keys and relationships
        modelBuilder.Entity<UserName>()
            .HasKey(u => u.id_usuario);
        
        modelBuilder.Entity<UserName>()
            .HasOne(u => u.Usuario)
            .WithOne()
            .HasForeignKey<UserName>(u => u.id_usuario);
    }
}
