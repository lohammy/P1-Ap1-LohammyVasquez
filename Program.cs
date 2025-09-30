using Microsoft.EntityFrameworkCore;
using P1_Ap1_LohammyVasquez.Components;
using P1_Ap1_LohammyVasquez.DAL;
using P1_Ap1_LohammyVasquez.Models;
using P1_Ap1_LohammyVasquez.Services;
//using P1_Ap1_LohammyVasquez.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var ConStr = builder.Configuration.GetConnectionString("sqlConnection");

builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlite(ConStr));
builder.Services.AddScoped<EntradaHuacalesServices>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
