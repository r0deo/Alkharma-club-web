using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using AlKarmahClub.Application.Common.Models;
using AlKarmahClub.Tests.TestInfrastructure;

namespace AlKarmahClub.Tests.Integration.System;

public class SystemStatusEndpointTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task System_Status_Endpoint_Should_Return_Ok()
    {
        var response = await _client.GetAsync(TestConstants.SystemStatusEndpoint);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task System_Status_Endpoint_Should_Return_Success_True()
    {
        var response = await _client.GetAsync(TestConstants.SystemStatusEndpoint);
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();

        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeTrue();
    }

    [Fact]
    public async Task System_Status_Endpoint_Should_Return_Message_Containing_AlKarmahClub_API_Is_Running()
    {
        var response = await _client.GetAsync(TestConstants.SystemStatusEndpoint);
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();

        apiResponse!.Message.Should().Contain("AlKarmahClub API is running");
    }
}