using KilimoCloud.Data;

namespace KilimoCloud;

public static class InitializeDatabase
{
    public static void Init(ApplicationDBContext context)
    {
        //If there are no students or FormStreams, create some for testing purposes
        if (!context.FormStreams.Any() || !context.Students.Any())
        {
            ///-------------------form 1 A
            var form1a = new FormStream()
            {
                FormStreamId = Guid.NewGuid(),
                Name = "Form 1A"
            };
            context.FormStreams.Add(form1a);
            context.SaveChanges();
            ///-------------------form 1 A
            var form1b = new FormStream()
            {
                FormStreamId = Guid.NewGuid(),
                Name = "Form 1B"
            };
            context.FormStreams.Add(form1b);
            context.SaveChanges();
            ///-------------------form 1 A
            var form1c = new FormStream()
            {
                FormStreamId = Guid.NewGuid(),
                Name = "Form 1B"
            };
            context.FormStreams.Add(form1c);
            context.SaveChanges();
            for (int i = 0; i < 100; i++)
            {
                var phoneNumber = 0700000000;
                var stream = form1a;
                if (i % 2 == 0)
                {
                    stream = form1b;
                }
                if (i % 3 == 0)
                {
                    stream = form1c;
                }
                var student = new Student()
                {
                    Name = $"Student {i}",
                    Age = 14,
                    FormStream = stream,
                    Id = Guid.NewGuid(),
                    GuardianContact = (phoneNumber + (i * 30)).ToString()
                };
                context.Students.Add(student);
                context.SaveChanges();
            }
        }
    }
}