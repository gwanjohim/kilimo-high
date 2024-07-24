using KilmoniCloud.Data;

namespace KilmoniCloud;

public static class InitializeDatabase
{
    public static void Init(ApplicationDBContext context)
    {
        ///-------------------form 1 A
        var form1a = new ClassStream()
        {
            ClassStreamId = Guid.NewGuid(),
            Name = "Form 1A"
        };


        context.ClassStreams.Add(form1a);
        context.SaveChanges();


        ///-------------------form 1 A
        var form1b = new ClassStream()
        {
            ClassStreamId = Guid.NewGuid(),
            Name = "Form 1B"
        };


        context.ClassStreams.Add(form1b);
        context.SaveChanges();


        ///-------------------form 1 A
        var form1c = new ClassStream()
        {
            ClassStreamId = Guid.NewGuid(),
            Name = "Form 1B"
        };


        context.ClassStreams.Add(form1c);
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
                ClassStream = stream,
                Id = Guid.NewGuid(),
                GuardianContact = (phoneNumber + (i * 30)).ToString()
            };

            context.Students.Add(student);
            context.SaveChanges();
        }
    }
}