using Education.Data;

namespace Education.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IStudentRepository Student {get;}

    public ITeacherRepository Teacher {get;}

    public ICourseRepository Cource {get;}
    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Student = new StudentsRepository(context);
        Teacher = new TeacherRepository(context);
        Cource = new CourseRepository(context);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public int Save()
     => _context.SaveChanges();
}