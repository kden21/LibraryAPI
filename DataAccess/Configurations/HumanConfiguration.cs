using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class HumanConfiguration : IEntityTypeConfiguration<HumanEntity>
{
    public void Configure(EntityTypeBuilder<HumanEntity> builder)
    {
     
    }
}
