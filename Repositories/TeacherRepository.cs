using Education.Data;
using Education.Entities;

namespace Education.Repositories;
public class TeacherRepository : GenericRepository<Teacher> , ITeacherRepository
{
    public TeacherRepository(AppDbContext context): base(context){}
}