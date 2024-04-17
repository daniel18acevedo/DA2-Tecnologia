using Vidly.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .Services
    .AddControllers(options =>
    {
        options.Filters.Add<ExceptionFilter>();
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

var services = builder.Services;
var configuration = builder.Configuration;

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();