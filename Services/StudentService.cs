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
    public async ValueTask<Result<Student>> CreateAsync(StudentViewModel model)
    {
        if(model is null)
         return new(false);

        try
        {
         var createdStudent = await _unitOfWork.Student.AddAsync(Mappings.ToEntity(model));
        
         return new(true) {Data = createdStudent};
            
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("Student didn't  created");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<Student>> FindByName(string name)
    {
        if(string.IsNullOrEmpty(name))
         return new(false);

         try
         {
            var student =  _unitOfWork.Student.GetAll().FirstOrDefault(x => x.Name == name);
            
            return new(true) {Data = student};

         }
         catch (System.Exception e)
         {
            _logger.LogInformation($"Student didn't fin by name {e.Message}");
            throw new Exception(e.Message);
         }
    }

    public async ValueTask<Result<List<Student>>> GetAllStudentsAsync()
    {
        try
        {
         var students =  _unitOfWork.Student.GetAll().ToList();
         return new(true) { Data = students};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Students didn't take {e.Message}");
            throw new Exception(e.Message);
        }

    }

    public async ValueTask<Result<Student>> GetById(int id)
    {
        if(id<0)
         return new(false);

         try
         {
         var student = _unitOfWork.Student.GetById(id);

         return new(true) {Data = student};
            
         }
         catch (System.Exception e)
         {
            _logger.LogInformation($"Student didn't get by id {e.Message}");
            throw new Exception(e.Message);
         }

    }

    public async ValueTask<Result<Student>> RemoveByIdAsync(int id)
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
        return new(true) {Data = student};

        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"student didn't ");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<Student>> UpdateAsync(StudentViewModel model)
    {
      try
      {
        var student = await  _unitOfWork.Student.Update(Mappings.ToEntity(model));

        return new(true) {Data = student};
      }
      catch (System.Exception e)
      {
        _logger.LogInformation($"student didn't updatet");
        throw new Exception(e.Message);
      }
    }
   
}