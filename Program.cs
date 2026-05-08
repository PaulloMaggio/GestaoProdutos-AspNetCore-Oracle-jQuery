using Microsoft.EntityFrameworkCore;
using GestaoProdutosOracle.Data;
using GestaoProdutosOracle.Services;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
string connectionString = Env.GetString("ORACLE_CONNECTION");

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddScoped<IProdutoService, ProdutoService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        DbInitializer.Seed(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Erro ao povoar o banco de dados.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produtos}/{action=Index}/{id?}");

app.Run();