using System.ComponentModel.DataAnnotations;

namespace KilmoniCloud.Data;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string GuardianContact { get; set; }
    public virtual FormStream FormStream { get; set; }
    public Guid FormStreamId { get; set; }
}