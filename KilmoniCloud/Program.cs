using KilmoniCloud;
using KilmoniCloud.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(
        "Data Source=localhost;Initial Catalog=KilimoniCloud2;Persist Security Info=True;User ID=sa;Password=303mP$203;MultipleActiveResultSets=True;TrustServerCertificate=True");
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

var applicationDb = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
applicationDb.Database.EnsureCreated();


InitializeDatabase.Init(applicationDb);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();