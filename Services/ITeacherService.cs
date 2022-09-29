using Education.Models;

namespace Education.Services;

public interface ITeacherService
{
    ValueTask<Result<TeacherViewModel>> CreateAsync(TeacherViewModel model);
    ValueTask<Result<TeacherViewModel>> GetById(int id);
    ValueTask<Result<TeacherViewModel>> UpdateAsync(int id, TeacherViewModel model);
    ValueTask<Result<TeacherViewModel>> RemoveById(int id);  
}