using System.ComponentModel.DataAnnotations;

namespace KilmoniCloud.Data;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string GuardianContact { get; set; }
    public ClassStream ClassStream { get; set; }
    public Guid ClassStreamId { get; set; }
}