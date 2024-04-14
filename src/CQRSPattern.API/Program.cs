using CQRSPattern.API.DependencyInjection;
using CQRSPattern.API.Middlewares;
using CQRSPattern.CrossCutting.Constants;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseMiddleware<UnexpectedErrorMiddleware>();
}

app.UseHttpsRedirection();
app.UseCors(CorsNamesConstants.CorsPolicy);
app.UseAuthorization();
app.MapControllers();
app.MigrateDatabase();

app.Run();
