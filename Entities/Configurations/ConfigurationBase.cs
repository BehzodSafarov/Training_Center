using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Entities.Configurations;
public class ConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
      builder.HasKey(p => p.Id);
      builder.Property(p => p.Id).HasColumnType("integer").ValueGeneratedOnAdd();
      builder.Property(p => p.Name).HasMaxLength(50).IsRequired().IsRequired(true);
    }
}