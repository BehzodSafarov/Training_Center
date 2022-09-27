using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Entities.Configurations;
public class StudentConfiguration : ConfigurationBase<Student>
{
    public override void Configure(EntityTypeBuilder<Student> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Adress).HasMaxLength(60);
        builder.Property(p => p.Age).IsRequired(true);
        builder.Property(p => p.CourseNames).IsRequired(true);
    }
}