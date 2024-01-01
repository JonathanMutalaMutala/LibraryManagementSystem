using Blazored.LocalStorage;
using Blazored.Toast;
using Library.BlazorUI.Components;
using Library.BlazorUI.Configuration;
using Library.BlazorUI.Contracts.Book;
using Library.BlazorUI.Handlers;
using Library.BlazorUI.Providers;
using Library.BlazorUI.Services.Base;
using Library.BlazorUI.Services.BookServices;
using Microsoft.AspNetCore.Components.Authorization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<JwtAuthorizationMessageHandler>();


//builder.Services.AddHttpClient<IClientService, ClientService>(client =>  client.BaseAddress = new Uri(builder.Configuration.GetSection("Client")["Url"].ToString()));
builder.Services.AddHttpClient<IClient, Client>
    (Client => Client.BaseAddress = new Uri("https://localhost:7117"))
    .AddHttpMessageHandler<JwtAuthorizationMessageHandler>();


builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

// Ajout des services des pour les contrats 
builder.Services.AddContractsServices();
//builder.Services.AddScoped<IBookService, BookService>();

//Add AutoMapper Service
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
