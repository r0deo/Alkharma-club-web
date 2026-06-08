using AlKarmahClub.Application.Common.Models;
using FluentAssertions;

namespace AlKarmahClub.Tests.Unit.Common;

public class ApiResponseTests
{
    [Fact]
    public void Should_Create_Successful_ApiResponse_With_Data()
    {
        var data = new { Id = 1, Name = "Test" };
        var response = ApiResponse<object>.Ok(data, "Success message");

        response.Success.Should().BeTrue();
        response.Data.Should().BeEquivalentTo(data);
        response.Message.Should().Be("Success message");
        response.Errors.Should().BeEmpty();
    }

    [Fact]
    public void Should_Create_Successful_ApiResponse_With_Null_Data()
    {
        var response = ApiResponse<object>.Ok(null, "No content");

        response.Success.Should().BeTrue();
        response.Data.Should().BeNull();
        response.Message.Should().Be("No content");
    }

    [Fact]
    public void Should_Create_Failed_ApiResponse_With_Errors()
    {
        var errors = new[] { "Error 1", "Error 2" };
        var response = ApiResponse<object>.Fail(errors, "Validation failed");

        response.Success.Should().BeFalse();
        response.Errors.Should().NotBeNull();
        response.Errors.Should().HaveCount(2);
        response.Message.Should().Be("Validation failed");
    }

    [Fact]
    public void Failure_Response_Should_Have_Success_False()
    {
        var response = ApiResponse<string>.Fail(["Some error"]);

        response.Success.Should().BeFalse();
    }

    [Fact]
    public void Errors_Should_Not_Be_Null()
    {
        var response = ApiResponse<object>.Ok(null);

        response.Errors.Should().NotBeNull();
    }
}