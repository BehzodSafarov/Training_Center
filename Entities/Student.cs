using System.ComponentModel.DataAnnotations;

namespace Education.Entities;
public class Student : EntityBase
{
 public int Age { get; set; }
 public string? Adress { get; set; }
 
 [Required]
 public virtual List<Course>? CourseNames { get; set; }

}