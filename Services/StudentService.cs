using Education.Entities;
using Education.Models;
using Education.Mappers;
using Education.Repositories;

namespace Education.Services;
public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<StudentService> _logger;

    public StudentService(
    IUnitOfWork unitOfWork,
    ILogger<StudentService> logger)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
    }
    public async ValueTask<Result<StudentViewModel>> CreateAsync(StudentViewModel model)
    {
        if(model is null)
         return new(false);

        try
        {
         var existStudent = await FindByName(model?.Name);

         if((existStudent?.Data?.Adress == model.Adress &&
         existStudent?.Data?.Name == model.Name &&
         existStudent.Data.Age == model.Age))
         {
         _logger.LogInformation("Bu student bor edi");
         return new(" bu student bor edi");
         }
         else
         {

         var createdStudent = await _unitOfWork.Student.AddAsync(Mappings.ToEntity(model));
        
         return new(true) {Data = createdStudent.ToModel()};
         }
         
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("Student didn't  created");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<StudentViewModel>> FindByName(string name)
    {
        if(string.IsNullOrEmpty(name))
         return new(false);

         try
         {
            var student =  _unitOfWork.Student.GetAll().FirstOrDefault(x => x.Name == name);
            
            return new(true) {Data = student?.ToModel()};

         }
         catch (System.Exception e)
         {
            _logger.LogInformation($"Student didn't fin by name {e.Message}");
            throw new Exception(e.Message);
         }
    }

    public async ValueTask<Result<List<StudentViewModel>>> GetAllStudentsWithPaginationAsync(int page, int limit)
    {
        try
        {
         var existStudents = _unitOfWork.Student.GetAll();
         if(existStudents is null)
         return new("Students not found");

         var filteredStudents =  existStudents
         .Skip((page-1)*limit)
         .Take(limit)
         .Select(x => x.ToModel())
         .ToList();

         return new(true) { Data = filteredStudents};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Students didn't take {e.Message}");
            throw new Exception(e.Message);
        }

    }

    public async ValueTask<Result<StudentViewModel>> GetById(int id)
    {
        if(id<0)
         return new(false);

         try
         {
         var student = _unitOfWork.Student.GetById(id);

         return new(true) {Data = student?.ToModel()};
            
         }
         catch (System.Exception e)
         {
            _logger.LogInformation($"Student didn't get by id {e.Message}");
            throw new Exception(e.Message);
         }

    }

    public async ValueTask<Result<StudentViewModel>> RemoveByIdAsync(int id)
    {
        try
        {
        var student = _unitOfWork.Student.GetById(id);

        if(student is null)
        {
        _logger.LogInformation($"this student didn't find");
        return new(false);
        }
        student = await _unitOfWork.Student.Remove(student); 
        return new(true) {Data = student.ToModel()};

        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"student didn't ");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<StudentViewModel>> UpdateAsync(StudentViewModel model)
    {
      try
      {
        var student = await  _unitOfWork.Student.Update(Mappings.ToEntity(model));

        return new(true) {Data = student.ToModel()};
      }
      catch (System.Exception e)
      {
        _logger.LogInformation($"student didn't updatet");
        throw new Exception(e.Message);
      }
    }


}