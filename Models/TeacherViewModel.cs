using System.ComponentModel.DataAnnotations;

namespace Education.Models;
public class TeacherViewModel
{
 [Required]
 public int Age { get; set; }

 [Required,MaxLength(100)]
 public string? Adress { get; set; }

 [Required]
 public  List<CoureViewModel>? CourseNames { get; set; }

 public long  Salary { get; set; }   
 public EPatogs Patogs { get; set; }
}