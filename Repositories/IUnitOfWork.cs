namespace Education.Repositories;
public interface IUnitOfWork : IDisposable
{
 IStudentRepository Student {get;}
 ITeacherRepository Teacher {get;}
 ICourseRepository Cource {get;}
 int Save();
}