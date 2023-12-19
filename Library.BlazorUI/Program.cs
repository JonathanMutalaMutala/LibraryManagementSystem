using Library.BlazorUI.Components;
using Library.BlazorUI.Configuration;
using Library.BlazorUI.Contracts.Book;
using Library.BlazorUI.Services;
using Library.BlazorUI.Services.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddHttpClient<IClientService, ClientService>(client =>  client.BaseAddress = new Uri(builder.Configuration.GetSection("Client")["Url"].ToString()));
builder.Services.AddHttpClient<IClient, Client>
    (Client => Client.BaseAddress = new Uri("https://localhost:7117"));


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();




// Ajout des services des pour les contrats 
//builder.Services.AddContractsServices();
builder.Services.AddScoped<IBookService, BookService>();

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
