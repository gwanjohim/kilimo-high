using KilimoCloud;
using KilimoCloud.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString("KilimoDBConnection")
                       ?? throw new InvalidOperationException(
                           "Connection string 'KilimoDBConnection' not found.");


builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(connectionString);
});


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

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