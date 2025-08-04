using IWannaBOT.Services;

var builder = WebApplication.CreateBuilder(args);

// Додаємо підтримку контролерів
builder.Services.AddControllers();

// Додаємо HttpClient для відправки запитів
builder.Services.AddHttpClient();
builder.Services.AddSingleton<DishService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Спочатку шукаємо дефолтні файли (index.html) у wwwroot
app.UseDefaultFiles();

// Потім віддаємо статичні файли (css, js, html тощо)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
