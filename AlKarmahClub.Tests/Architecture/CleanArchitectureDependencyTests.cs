using AlKarmahClub.Application.Common.Models;
using AlKarmahClub.Domain.Common;

namespace AlKarmahClub.Tests.Architecture;

public sealed class CleanArchitectureDependencyTests
{
    [Fact]
    public void Domain_Should_Not_Depend_On_Infrastructure_Or_Api()
    {
        var referencedAssemblies = typeof(BaseEntity).Assembly.GetReferencedAssemblies();

        Assert.DoesNotContain(referencedAssemblies, assembly => assembly.Name == "AlKarmahClub.Infrastructure");
        Assert.DoesNotContain(referencedAssemblies, assembly => assembly.Name == "AlKarmahClub.Api");
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure_Or_Api()
    {
        var referencedAssemblies = typeof(ApiResponse<>).Assembly.GetReferencedAssemblies();

        Assert.DoesNotContain(referencedAssemblies, assembly => assembly.Name == "AlKarmahClub.Infrastructure");
        Assert.DoesNotContain(referencedAssemblies, assembly => assembly.Name == "AlKarmahClub.Api");
    }
}
