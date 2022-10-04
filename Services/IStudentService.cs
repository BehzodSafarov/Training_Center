using Education.Entities;
using Education.Models;

namespace Education.Services;
public interface IStudentService
{
 ValueTask<Result<StudentViewModel>> CreateAsync(StudentViewModel model);
 ValueTask<Result<List<StudentViewModel>>> GetAllStudentsWithPaginationAsync(int page, int limit); 
 ValueTask<Result<StudentViewModel>> GetById(int id);
 ValueTask<Result<StudentViewModel>> RemoveByIdAsync(int id);
 ValueTask<Result<StudentViewModel>> UpdateAsync(StudentViewModel model);
 ValueTask<Result<StudentViewModel>> FindByName(string name);
 }