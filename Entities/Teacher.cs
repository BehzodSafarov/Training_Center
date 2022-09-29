using System.ComponentModel.DataAnnotations;

namespace Education.Entities;
public class Teacher : EntityBase
{
 public int Age { get; set; }
 public string? Adress { get; set; }
 [Required]
 public virtual List<Course>? CourseNames { get; set; }
//  public EPatogs Patogs { get; set; }
 public long  Salary { get; set; }   
}