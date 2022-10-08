using Education.Models;
using Education.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.Controllers;


public class StudentController : Controller
{
    private readonly IStudentService _service;
    private readonly ILogger<StudentController> _logger;

    public StudentController(
     ILogger<StudentController> logger,
     IStudentService service)
    {
     _service = service;
     _logger = logger;
    }

      public IActionResult Create() => View();

      [HttpPost]
      public async Task<IActionResult> Create(StudentViewModel model)
      {
        try
        {
          var createdstudent = await _service.CreateAsync(model); 

          return View();

        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Student model didn't created {e.Message}");
            throw new Exception(e.Message);
        }

      }
      
      public  IActionResult Remove(int id)
      {
            if(id < 0)
             return BadRequest("Id manfiy bo'lishi mumkin emas");
            
          try
          {
            var reomvedStudent = _service.RemoveByIdAsync(id);

            return RedirectToAction(nameof(List));
          }
          catch (System.Exception e)
          {
              _logger.LogInformation($"Student didn't removed");
              throw new Exception(e.Message);
          }
      }
      [HttpGet]
      public IActionResult Update(string returnUrl) => View();

      public async Task<IActionResult> Update(int id,StudentViewModel model ) 
      {
        if(id < 0)
        return new BadRequestResult();

        try
        {
          var student = await _service.GetById(id);

          if(student is null)
          return BadRequest("this student isn't exist in database.");

          await _service.UpdateAsync(model);
          return View();
        }
        catch (System.Exception e)
        {
          _logger.LogInformation($"Student didn't updated {e.Message}");
          throw new Exception();
        }
      }

      [Authorize(Roles ="admin")]
      [HttpGet]
      public async Task<IActionResult> List(int page=0,int limit=10)
      {
          if(page < 0 || limit < 0)
          return BadRequest("limit or page is null here");
          
        try
        {
          var filteredStudents = await _service.GetAllStudentsWithPaginationAsync(page,limit);
          _logger.LogInformation("");
          return View(filteredStudents?.Data);
        }
        catch (System.Exception e)
        {
          _logger.LogInformation($"Students didn't taked");
          throw new Exception();
        }
      }

      [HttpGet]
      public IActionResult FindByName() => View();

      [HttpGet]
      public async Task<IActionResult> FindByName(string name)
      {
        if(string.IsNullOrWhiteSpace(name))
        return BadRequest("Name is false");
        try
        {
          var student = await _service.FindByName(name);

          if(student is null)
          return BadRequest("This student is not exist");

          return View(student.Data);
        }
        catch (System.Exception e)
        {
          _logger.LogInformation($"This student is not taked");
          throw new Exception(e.Message);
        }
      }

}