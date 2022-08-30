using DataAccess.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class LibraryApiDbContext : DbContext
{
    public LibraryApiDbContext(DbContextOptions<LibraryApiDbContext> options)
        : base(options)
    {
    }
    
    //public DbSet<LibraryEntity> Libraries{ get; set; } 
    //public DbSet<HumanEntity> Humans{ get; set; } 
    //public DbSet<BookEntity> Books{ get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new HumanConfiguration());
    }
}