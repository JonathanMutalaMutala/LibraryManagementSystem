using LibraryManagementSystem.Application;
using LibraryManagementSystem.Persistence;
using LibraryManagementSystem.Infrastructure;
using LibraryManagementSyst.API.Middleware;
using LibraryManagementSystem.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Others Services 
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfraStructureServices();
builder.Services.AddIdentityServices(builder.Configuration);

//Permettre à L'API de recevoir d'autre requetes 
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("all");
app.UseAuthorization();

app.MapControllers();

app.Run();
