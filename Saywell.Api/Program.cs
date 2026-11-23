using Saywell.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Registers controller infrastructure
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Registers the ProverbService as a singleton service in the dependency injection container.
builder.Services.AddSingleton<ProverbService>();

// creates the configured application and its dependency injection container.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
// maps controller actions to HTTP endpoints based on their routing attributes.
app.MapControllers();
// starts the application and begins accepting HTTP requests.
app.Run();
