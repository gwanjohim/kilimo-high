using KilmoniCloud.Data;

namespace KilmoniCloud;

public static class InitializeDatabase
{
    public static void Init(ApplicationDBContext context)
    {
        for (int i = 0; i < 100; i++)
        {
            var phoneNumber = 0700000000;
            var stream = ClassStream.Form1A;

            if (i % 2 == 0)
            {
                stream = ClassStream.Form1B;
            }

            if (i % 3 == 0)
            {
                stream = ClassStream.Form1C;
            }

            var student = new Student()
            {
                Name = $"Student {i}",
                Age = 14,
                ClassStream = stream,
                Id = Guid.NewGuid(),
                GuardianContact = (phoneNumber + (i * 30)).ToString()
            };

            context.Students.Add(student);
            context.SaveChanges();
        }
    }
}