using Education.Entities;
using Education.Models;

namespace Education.Mappers;
public static class Mappings
{
    public static Student ToEntity(this StudentViewModel model)
      => new Student()
    {
      Name = model.Name,
      Age = model.Age, 
      Adress = model.Adress,
      CourseNames = model?.CourseNames
    };

    public static Course ToEntityCourse(this CourseViewModel model) 
     => new Course()
     {
       Name = model.CourseName,
       Duration = model.Duration,
       Price = model.Price 
     };

     public static StudentViewModel ToModel(this Student entity)
      => new StudentViewModel()
      {
      Id = entity.Id,
      Name = entity.Name,
      Age = entity.Age,
      Adress = entity.Adress,
      CourseNames = entity?.CourseNames
      };
     
     public static CourseViewModel ToModelCourse(this Course entity) 
        => new CourseViewModel()
     {
       Id = entity.Id,
       CourseName = entity.Name,
       Duration = entity.Duration,
       Price = entity.Price
     };
    
    public static Teacher ToEntity(this TeacherViewModel model)
     => new Teacher
     {
       Name = model.Name,
       Adress = model.Adress,
       Age = model.Age,
       Salary = model.Salary,
       CourseNames = model?.CourseNames?.Select(e => e.ToEntityCourse()).ToList()
     };

     public static TeacherViewModel ToModel(this Teacher entity)
     => new TeacherViewModel
     {
       Name = entity.Name,
       Adress = entity.Adress,
       Age = entity.Age,
       Salary = entity.Salary,
       CourseNames = entity?.CourseNames?.Select(e => e.ToModelCourse()).ToList()
     };
}