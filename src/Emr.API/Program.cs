using Emr.API;
using Emr.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation();
    builder.AddApplicationServices();
}

// Add services to the container.
//builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
