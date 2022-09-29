using Education.Entities;
using Education.Models;

namespace Education.Services;
public interface ICourseService
{
    ValueTask<Result<CourseViewModel>> CreateAsync(CourseViewModel model);
    ValueTask<Result<CourseViewModel>> GetById(int id);
    ValueTask<Result<CourseViewModel>> UpdateAsync(int id, CourseViewModel model);
    ValueTask<Result<CourseViewModel>> RemoveById(int id);
    
}