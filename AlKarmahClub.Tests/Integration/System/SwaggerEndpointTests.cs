using System.Net;
using FluentAssertions;
using AlKarmahClub.Tests.TestInfrastructure;

namespace AlKarmahClub.Tests.Integration.System;

public class SwaggerEndpointTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Swagger_Endpoint_Should_Return_Ok_Or_Redirect()
    {
        var response = await _client.GetAsync(TestConstants.SwaggerEndpoint);

        var allowedStatuses = new[]
        {
            HttpStatusCode.OK,
            HttpStatusCode.Redirect,
            HttpStatusCode.MovedPermanently,
            HttpStatusCode.Found,
            HttpStatusCode.TemporaryRedirect,
            HttpStatusCode.PermanentRedirect
        };

        allowedStatuses.Should().Contain(response.StatusCode, "Swagger endpoint should return 200 or a redirect");
    }

    [Fact]
    public async Task Swagger_Index_Endpoint_Should_Return_Ok()
    {
        var response = await _client.GetAsync(TestConstants.SwaggerIndexEndpoint);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Swagger_Index_Endpoint_Should_Return_Html_Content()
    {
        var response = await _client.GetAsync(TestConstants.SwaggerIndexEndpoint);

        var contentType = response.Content.Headers.ContentType?.MediaType;
        contentType.Should().NotBeNullOrEmpty();
        contentType.Should().Be("text/html");
    }
}