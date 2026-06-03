using AlKarmahClub.Api.Common;
using AlKarmahClub.Api.Middleware;
using Serilog;

namespace AlKarmahClub.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApiPipeline(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseSerilogRequestLogging();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors(CorsPolicyNames.Frontend);

        app.MapHealthChecks("/health");
        app.MapControllers();

        return app;
    }
}
