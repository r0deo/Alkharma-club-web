using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using AlKarmahClub.Application.Common.Models;
using AlKarmahClub.Tests.TestInfrastructure;

namespace AlKarmahClub.Tests.Integration.System;

public class GlobalExceptionMiddlewareTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Throw_Not_Found_Should_Return_Bad_Request_With_ApiResponse()
    {
        var response = await _client.GetAsync(TestConstants.TestEndpointNotFound);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeFalse();
        apiResponse.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Throw_Validation_Should_Return_Bad_Request_With_ApiResponse()
    {
        var response = await _client.GetAsync(TestConstants.TestEndpointValidation);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeFalse();
        apiResponse.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Throw_Unhandled_Should_Return_Internal_Server_Error_With_ApiResponse()
    {
        var response = await _client.GetAsync(TestConstants.TestEndpointUnhandled);

        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeFalse();
        apiResponse.Errors.Should().NotBeEmpty();
    }
}