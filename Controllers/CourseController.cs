using Education.Models;
using Education.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.Controllers;
public partial class CourseController : Controller
{
    private readonly ILogger<CourseController> _logger;
    private readonly ICourseService _service;

    public CourseController(
    ILogger<CourseController> logger,
    ICourseService service)
    {
      _logger = logger;
      _service = service;  
    }

  
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CourseViewModel model)
    {
      try
      {
       
        _logger.LogInformation($"Shu yergacha keldi");
        var createdCourse = await _service.CreateAsync(model);

        return View();
      }
      catch (System.Exception e)
      {
        _logger.LogInformation($"Course model didn't created {e.Message}");
        throw new Exception();
      }
    }

    [HttpGet]
    public IActionResult Get() => View();

    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        if(id < 0)
           return BadRequest("Id is false");

      try
      {
        var course = await _service.GetById(id);
        _logger.LogInformation($"Course olindi");

        return View(course);
      }
      catch (System.Exception e)
      {
        _logger.LogInformation($"Course didn't taked {e.Message}");
        throw new Exception();
      }
    } 

    [HttpGet]
    public IActionResult Remove() => View();

    [HttpDelete]
    public async Task<IActionResult> Remove(int id)
    {
        if(id < 0)
           return BadRequest("Id is false");

        try
        {
            await _service.RemoveById(id);
            _logger.LogInformation("Course is removed");

            return View();
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Course didn't removed {e.Message}");
            throw new Exception();
        }
    }
   [HttpGet]
   public IActionResult GetWithPagination() => View();

   [HttpGet]
   public async Task<IActionResult> GetWithPagination(int page,int limit)
   {
    if(page < 0 || limit < 0)
       return BadRequest("page or limit is false");

    try
    {
     var courses = await _service.GetAllCoursesWithPaginationAsync(page, limit);

    //  foreach (var item in courses.Data.ToList())
    //  {
    //    System.Console.WriteLine(item.CourseName);
    //  }
     _logger.LogInformation("Taked courses");

     return View(courses.Data);
    }

    catch (System.Exception e)
    {
        _logger.LogInformation($"Course didn't taked");
        
        throw new Exception();
    }
   }
}