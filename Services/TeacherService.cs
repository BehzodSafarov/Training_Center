using Education.Models;
using Education.Mappers;
using Education.Repositories;

namespace Education.Services;

public class TeacherService : ITeacherService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TeacherService> _logger;

    public TeacherService(
    ILogger<TeacherService> logger,
    IUnitOfWork unitOfWork)
    {
     _unitOfWork = unitOfWork;
     _logger = logger;        
    }
    public async ValueTask<Result<TeacherViewModel>> CreateAsync(TeacherViewModel model)
    {
      try
      {
        var createdTeacher = await _unitOfWork.Teacher.AddAsync(model.ToEntity());

        return new(true) {Data = createdTeacher.ToModel()};
      }
      catch (System.Exception e)
      {
        _logger.LogInformation($"Teacher didn't created {e.Message}");
        throw new Exception(e.Message);
      }
    }

    public async ValueTask<Result<TeacherViewModel>> GetById(int id)
    {
        if(id < 0)
         return new(false);
        try
        {
         var teache = _unitOfWork.Teacher.GetById(id);

         return new(true){Data = teache?.ToModel()};   
        }
        catch (System.Exception e)
        {
        _logger.LogInformation($"Teacher didn't take {e.Message}");
        throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<TeacherViewModel>> RemoveById(int id)
    {
        try
        {
            var existTeacher = _unitOfWork.Teacher.GetById(id);
            if(existTeacher is null)
             return new(false); 
           
            var removedTeacher = await _unitOfWork.Teacher.Remove(existTeacher);

            return new(true) {Data = removedTeacher.ToModel()};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Teacher didn't removed {e.Message}");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<TeacherViewModel>> UpdateAsync(int id, TeacherViewModel model)
    {
        try
        {
            var existTeacher = _unitOfWork.Teacher.GetById(id);
            if(existTeacher is null)
             return new(false);
             
             existTeacher.Adress = model.Adress;
             existTeacher.Age = model.Age;
             existTeacher.CourseNames = model?.CourseNames?.Select(e => e.ToEntityCourse()).ToList();
             existTeacher.Salary = model.Salary;
             
             var updatedTeacher = await _unitOfWork.Teacher.Update(existTeacher);

            return new(true) {Data = updatedTeacher.ToModel()};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Teacher didn't updated {e.Message}");
            throw new Exception(e.Message);
        }
    }
}