using AlKarmahClub.Application;
using AlKarmahClub.Domain.Common;
using AlKarmahClub.Infrastructure.Persistence;

namespace AlKarmahClub.Tests.Unit;

public sealed class SolutionBuildTests
{
    [Fact]
    public void Solution_Projects_Should_Load()
    {
        Assert.NotNull(typeof(Program).Assembly);
        Assert.NotNull(typeof(DependencyInjection).Assembly);
        Assert.NotNull(typeof(BaseEntity).Assembly);
        Assert.NotNull(typeof(AppDbContext).Assembly);
    }
}
