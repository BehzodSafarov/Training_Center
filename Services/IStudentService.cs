using Education.Entities;
using Education.Models;

namespace Education.Services;
public interface IStudentService
{
 ValueTask<Result<Student>> CreateAsync(StudentViewModel model);
 ValueTask<Result<List<Student>>> GetAllStudentsAsync(); 
 ValueTask<Result<Student>> GetById(int id);
 ValueTask<Result<Student>> RemoveByIdAsync(int id);
 ValueTask<Result<Student>> UpdateAsync(StudentViewModel model);
 ValueTask<Result<Student>> FindByName(string name);

}