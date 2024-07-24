using System.ComponentModel.DataAnnotations;

namespace KilimoCloud.Data;

public class Student
{
    public Guid Id { get; set; }
    [MaxLength(200)] [Required] public string Name { get; set; }
    [Required] public int Age { get; set; }

    [Display(Name = "Guardian Contact")]
    [MaxLength(200)]
    [Required]
    public string GuardianContact { get; set; }
    public virtual FormStream? FormStream { get; set; }
    [Required()] public Guid FormStreamId { get; set; }
}