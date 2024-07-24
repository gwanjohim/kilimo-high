namespace KilmoniCloud.Data;

public enum ClassStream
{
    Form1A,
    Form1B,
    Form1C
}

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string GuardianContact { get; set; }

    public ClassStream ClassStream { get; set; }
}