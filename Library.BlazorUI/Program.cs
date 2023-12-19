using Library.BlazorUI.Components;
using Library.BlazorUI.Configuration;
using MyNamespace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


//builder.Services.AddHttpClient<IClientService, ClientService>(client =>  client.BaseAddress = new Uri(builder.Configuration.GetSection("Client")["Url"].ToString()));
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("http://localhost:5019"));


// Ajout des services des pour les contrats 
builder.Services.AddContractsServices();

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
