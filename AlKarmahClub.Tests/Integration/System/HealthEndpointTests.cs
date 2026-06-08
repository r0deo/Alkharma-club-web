using System.Net;
using FluentAssertions;
using AlKarmahClub.Tests.TestInfrastructure;

namespace AlKarmahClub.Tests.Integration.System;

public class HealthEndpointTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Health_Endpoint_Should_Return_Ok()
    {
        var response = await _client.GetAsync(TestConstants.HealthEndpoint);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}