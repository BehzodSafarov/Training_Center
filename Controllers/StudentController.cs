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
 [Authorize(Roles ="Teacherr")]
  public IActionResult Create() => View();

  [HttpPost]
  public async Task<IActionResult> Create(StudentViewModel model)
  {
    try
    {
     var createdstudent = await _service.CreateAsync(model); 

     _logger.LogInformation($"Student model yaratildi");

     return View();
    }
    catch (System.Exception e)
    {
        _logger.LogInformation($"Student model didn't created {e.Message}");
        throw new Exception(e.Data.ToString());
    }

  }

  public IActionResult RemoveStudent(string returnUrl) => View();

  [HttpPost]
  public  IActionResult Remove(int id)
  {
    if(id < 0)
     return BadRequest("Id manfiy bo'lishi mumkin emas");
   try
   {
     var reomvedStudent = _service.RemoveByIdAsync(id);

     return View();
   }
   catch (System.Exception e)
   {
    _logger.LogInformation($"Student didn't removed");
    throw new Exception(e.Message);
   }
  }

}