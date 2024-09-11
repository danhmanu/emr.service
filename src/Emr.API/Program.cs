using Emr.API;
using Emr.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation();
    builder.AddApplicationServices();
}

var ConnectionString = builder.Configuration.GetConnectionString("icaredb");
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
