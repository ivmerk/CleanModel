using CleanModel;
using CleanModel.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<FakeDataRepository>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var fakeDataRepository = services.GetRequiredService<FakeDataRepository>();

    // Заполнение базы данных фейковыми данными
    fakeDataRepository.SeedDatabase(100);
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();

    // Запрос данных из базы данных
    var products = dbContext.Products.ToList();

    // Вывод данных в консоль
    foreach (var product in products)
    {
        Console.WriteLine($"Product Name: {product.Name}, Description: {product.Description}, Price: {product.Price}");
    }
}
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
