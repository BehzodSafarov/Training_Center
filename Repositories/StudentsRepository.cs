using Education.Data;
using Education.Entities;

namespace Education.Repositories;
public class StudentsRepository : GenericRepository<Student>,IStudentRepository
{
    public StudentsRepository(AppDbContext context)
      :base(context){} 
    
}