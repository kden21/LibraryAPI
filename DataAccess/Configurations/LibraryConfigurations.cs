using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class LibraryConfigurations : IEntityTypeConfiguration<LibraryEntity>
{
    public void Configure(EntityTypeBuilder<LibraryEntity> builder)
    {
     
    }
}