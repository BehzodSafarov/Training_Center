using System.ComponentModel.DataAnnotations;

namespace Education.Models;
public class StudentViewModel 
{
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string? Name { get; set; }
    
    [Required]
    public int Age { get; set; }
    [Required,MaxLength(100)]
    public string? Adress { get; set; }
    [Required]
    public List<CourseViewModel>? CourseNames { get; set; }
}