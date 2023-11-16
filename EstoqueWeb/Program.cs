using EstoqueWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DbEstoque");

builder.Services.AddDbContext<Context>(options => options.UseMySql(connection,
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("3.0.38-mysql")));

//Este e o cadigo da autenticação
builder.Services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", options =>
{
    options.LoginPath = "/Login/Entrar";
    options.AccessDeniedPath = "/Login/Ops";
});


var app = builder.Build();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
