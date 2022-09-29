using System.ComponentModel.DataAnnotations;

namespace Education.Models;
public class CourseViewModel 
{
  public int Id { get; set; }
  [Required,MaxLength(50)]
  public string? CourseName { get; set; }  
  [Required]
  public DateTime Duration { get; set; }
  [Required]
  public long Price { get; set; }
}