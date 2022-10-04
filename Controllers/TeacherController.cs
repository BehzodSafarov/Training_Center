using Education.Models;
using Education.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.Controllers;

[Authorize(Roles = "admin")]
public class TeacherController : Controller
{
    private readonly ILogger<TeacherController> _logger;
    private readonly ITeacherService _service;

    public TeacherController(
    ILogger<TeacherController> logger,
    ITeacherService service)
    {
        _logger = logger;
        _service = service;
    }

  [HttpGet]
  public IActionResult Create() => View();

  [HttpPost]
  public async Task<IActionResult> Create(TeacherViewModel model)
  {
    try
    {
       var createdTeacher = await _service.CreateAsync(model);

       return View(createdTeacher.Data);

    }
    catch (System.Exception e)
    {
        _logger.LogInformation($"Teacher didn't created {e.Message}");   
        throw new Exception();
    }
  }

  [HttpGet]
  public  IActionResult GetByName() => View();

  [HttpGet]
  public async Task<IActionResult> GetById(int id)
  {
   if(id < 0)
   return BadRequest("id is false");

   try
   {
     var teache = await _service.GetById(id);

     return View(teache.Data);
   }
   catch (System.Exception)
   {
    _logger.LogInformation("didn't taked teacher");
    throw new Exception();
   }

  }

[HttpGet]
 public IActionResult Update() => View();

 [HttpPut]
 public IActionResult Update(int id,TeacherViewModel model)
 {
   if(id < 0)
   return BadRequest("id is false");

   try
   {
     var updatedTeacher =  _service.UpdateAsync(id,model);

     return View(updatedTeacher);
   }
   catch (System.Exception e)
   {
    _logger.LogInformation($"Teacher didn't updated");
    throw new Exception(e.Message);
   }
 }

 [HttpGet]
 public IActionResult Remove() => View();

 [HttpDelete]
 public IActionResult Renove(int id)
 {
   if(id < 0)
   return BadRequest("Id is false");

   try
   {
     var removedTeacher = _service.RemoveById(id);

     return View(removedTeacher);
   }
   catch (System.Exception e)
   {
    _logger.LogInformation($"Teacher didn't removed");
    throw new Exception(e.Message);
   }
 }
  
  
}