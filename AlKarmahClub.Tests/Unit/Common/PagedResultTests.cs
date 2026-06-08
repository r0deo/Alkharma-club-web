using AlKarmahClub.Application.Common.Models;
using FluentAssertions;

namespace AlKarmahClub.Tests.Unit.Common;

public class PagedResultTests
{
    [Fact]
    public void Should_Calculate_TotalPages_Correctly()
    {
        var result = new PagedResult<object>
        {
            Items = [],
            PageNumber = 1,
            PageSize = 10,
            TotalCount = 25
        };

        result.TotalPages.Should().Be(3);
    }

    [Fact]
    public void Should_Calculate_TotalPages_Correctly_With_Exact_Multiple()
    {
        var result = new PagedResult<object>
        {
            Items = [],
            PageNumber = 1,
            PageSize = 10,
            TotalCount = 20
        };

        result.TotalPages.Should().Be(2);
    }

    [Fact]
    public void Should_Return_Zero_TotalPages_When_PageSize_Is_Zero()
    {
        var result = new PagedResult<object>
        {
            Items = [],
            PageNumber = 1,
            PageSize = 0,
            TotalCount = 25
        };

        result.TotalPages.Should().Be(0);
    }

    [Fact]
    public void Should_Store_PageNumber_PageSize_TotalCount()
    {
        var result = new PagedResult<string>
        {
            Items = ["item1", "item2"],
            PageNumber = 2,
            PageSize = 25,
            TotalCount = 100
        };

        result.PageNumber.Should().Be(2);
        result.PageSize.Should().Be(25);
        result.TotalCount.Should().Be(100);
    }

    [Fact]
    public void Items_Should_Not_Be_Null()
    {
        var result = new PagedResult<object>();

        result.Items.Should().NotBeNull();
    }
}