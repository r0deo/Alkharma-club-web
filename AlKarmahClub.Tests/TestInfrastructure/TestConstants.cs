namespace AlKarmahClub.Tests.TestInfrastructure;

public static class TestConstants
{
    public const string HealthEndpoint = "/health";
    public const string SystemStatusEndpoint = "/api/system/status";
    public const string SwaggerEndpoint = "/swagger";
    public const string SwaggerIndexEndpoint = "/swagger/index.html";
    
    public const string TestEndpointNotFound = "/api/test/throw-not-found";
    public const string TestEndpointValidation = "/api/test/throw-validation";
    public const string TestEndpointUnhandled = "/api/test/throw-unhandled";
}