using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Entities.Configurations;
public class TeacherConfiguration : ConfigurationBase<Teacher>
{
    public override void Configure(EntityTypeBuilder<Teacher> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Adress).HasMaxLength(60).IsRequired(true);
        builder.Property(p => p.Age).IsRequired(true);
        builder.Property(p => p.CourseNames).HasMaxLength(100).IsRequired(true);
        builder.Property(p => p.Salary).IsRequired(true);
    }
}