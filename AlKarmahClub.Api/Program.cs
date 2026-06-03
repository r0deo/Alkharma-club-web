using AlKarmahClub.Api.Extensions;
using AlKarmahClub.Application;
using AlKarmahClub.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

app.UseApiPipeline();

app.Run();

public partial class Program;
