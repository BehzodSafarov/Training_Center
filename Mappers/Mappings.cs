using Education.Entities;
using Education.Models;

namespace Education.Mappers;
public static class Mappings
{
    public static Student ToEntity(StudentViewModel model)
     => new Student()
    {
      Name = model.Name,
      Age = model.Age,
      Adress = model.Adress,
      CourseNames = model?.CourseNames?.Select(e => ToEntityCourse(e)).ToList()
    };

    public static Course ToEntityCourse(CoureViewModel model) 
     => new Course()
     {
       Name = model.CourseName,
       Duration = model.Duration,
       Price = model.Price
     };

     public static StudentViewModel ToModel(Student entity)
      => new StudentViewModel()
      {
      Id = entity.Id,
      Name = entity.Name,
      Age = entity.Age,
      Adress = entity.Adress,
      CourseNames = entity?.CourseNames?.Select(e => ToModelCourse(e)).ToList()
      };
     
     public static CoureViewModel ToModelCourse(Course entity) 
       => new CoureViewModel()
     {
       Id = entity.Id,
       CourseName = entity.Name,
       Duration = entity.Duration,
       Price = entity.Price
     };
    
}