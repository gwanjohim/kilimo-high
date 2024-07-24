using Microsoft.EntityFrameworkCore;

namespace KilmoniCloud.Data;

public class ApplicationDBContext : DbContext
{
    public DbSet<Student> Students { get; set; }
}