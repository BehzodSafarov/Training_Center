using Education.Data;
using Education.Entities;

namespace Education.Repositories;
public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context):base(context){}
}