using Education.Models;
using Education.Mappers;
using Education.Repositories;

namespace Education.Services;
public class CourseService : ICourseService
{
    private readonly ILogger<CourseService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(
    ILogger<CourseService> logger,
    IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    public async ValueTask<Result<CourseViewModel>> CreateAsync(CourseViewModel model)
    {
        try
        {
           var course  = await _unitOfWork.Cource.AddAsync(model.ToEntityCourse());

           return new(true) {Data = course.ToModelCourse()};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Course didn't created{e.Message}");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<CourseViewModel>> GetById(int id)
    {
        if(id < 0)
          return new(false);

        try
        {
            var course = _unitOfWork.Cource.GetById(id);

            return new(true) {Data = course?.ToModelCourse()};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Couse didn't taked {e.Message}");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<CourseViewModel>> RemoveById(int id)
    {
        if(id < 0)
         return new(false);
         
         try
         {
            var existCourse = _unitOfWork.Cource.GetById(id);
            if(existCourse is null)
             return new(false);

            var removedCourse = await _unitOfWork.Cource.Remove(existCourse);

            return new(true) {Data = removedCourse.ToModelCourse()};
         }

         catch (System.Exception e)
         {
            _logger.LogInformation($"Coursedidn't Remove {e.Message}");
            throw new Exception(e.Message);
         }
    }

    public async ValueTask<Result<CourseViewModel>> UpdateAsync(int id, CourseViewModel model)
    {
        try
        {
            var existCourse =  _unitOfWork.Cource.GetById(id);
            if(existCourse is null)
             return new(false);

            existCourse.Duration = model.Duration;
            existCourse.Name = model.CourseName;
            existCourse.Price = model.Price;
            
            return new(true) {Data = existCourse.ToModelCourse()};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($" Course didn't updated {e.Message}");
            throw;
        }
    }
}