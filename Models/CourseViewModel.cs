using System.ComponentModel.DataAnnotations;

namespace Education.Models;
public class CourseViewModel 
{
  public int Id { get; set; }
  public string? CourseName { get; set; }  
  public string? Duration { get; set; }
  public long Price { get; set; }
}