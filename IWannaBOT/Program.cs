using IWannaBOT.Services;

var builder = WebApplication.CreateBuilder(args);

// ������ �������� ����������
builder.Services.AddControllers();

// ������ HttpClient ��� �������� ������
builder.Services.AddHttpClient();
builder.Services.AddSingleton<DishService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// �������� ������ ������� ����� (index.html) � wwwroot
app.UseDefaultFiles();

// ���� ������ ������� ����� (css, js, html ����)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
