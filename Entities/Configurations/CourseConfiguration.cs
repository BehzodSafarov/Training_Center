using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Entities.Configurations;
public class CourseConfiguration : ConfigurationBase<Course>
{
    public override void Configure(EntityTypeBuilder<Course> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Duration).IsRequired(true);
        builder.Property(p => p.Price).IsRequired(true);
    }
}