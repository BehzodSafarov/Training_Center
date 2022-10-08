using System.ComponentModel.DataAnnotations;

namespace Education.Models;
public class StudentViewModel 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Adress { get; set; }
    public string? CourseNames { get; set; }
}