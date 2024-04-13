using CQRSPattern.API.DependencyInjection;
using CQRSPattern.CrossCutting.Constants;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection(configuration);
builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(CQRSPattern.Application.AssemblyReference.Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(CorsNamesConstants.CorsPolicy);
app.UseAuthorization();
app.MapControllers();
app.MigrateDatabase();

app.Run();
