using AlKarmahClub.Api;
using AlKarmahClub.Application;
using AlKarmahClub.Domain;
using AlKarmahClub.Infrastructure;
using NetArchTest.Rules;
using FluentAssertions;

namespace AlKarmahClub.Tests.Architecture;

public class CleanArchitectureTests
{
    [Fact]
    public void Domain_Should_Not_Depend_On_Application_Infrastructure_Or_Api()
    {
        var assembly = typeof(DomainMarker).Assembly;

        var result1 = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOn("AlKarmahClub.Application")
            .GetResult();

        var result2 = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOn("AlKarmahClub.Infrastructure")
            .GetResult();

        var result3 = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOn("AlKarmahClub.Api")
            .GetResult();

        result1.IsSuccessful.Should().BeTrue("Domain should not depend on Application");
        result2.IsSuccessful.Should().BeTrue("Domain should not depend on Infrastructure");
        result3.IsSuccessful.Should().BeTrue("Domain should not depend on Api");
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure_Or_Api()
    {
        var assembly = typeof(ApplicationMarker).Assembly;

        var result1 = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOn("AlKarmahClub.Infrastructure")
            .GetResult();

        var result2 = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOn("AlKarmahClub.Api")
            .GetResult();

        result1.IsSuccessful.Should().BeTrue("Application should not depend on Infrastructure");
        result2.IsSuccessful.Should().BeTrue("Application should not depend on Api");
    }

    [Fact]
    public void Infrastructure_Should_Not_Depend_On_Api()
    {
        var assembly = typeof(InfrastructureMarker).Assembly;

        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOn("AlKarmahClub.Api")
            .GetResult();

        result.IsSuccessful.Should().BeTrue("Infrastructure should not depend on Api");
    }

    [Fact]
    public void Api_Should_Not_Be_Referenced_By_Domain_Or_Application()
    {
        var domainAssembly = typeof(DomainMarker).Assembly;
        var applicationAssembly = typeof(ApplicationMarker).Assembly;

        var result1 = Types.InAssembly(domainAssembly)
            .ShouldNot()
            .HaveDependencyOn("AlKarmahClub.Api")
            .GetResult();

        var result2 = Types.InAssembly(applicationAssembly)
            .ShouldNot()
            .HaveDependencyOn("AlKarmahClub.Api")
            .GetResult();

        result1.IsSuccessful.Should().BeTrue("Api should not be referenced by Domain");
        result2.IsSuccessful.Should().BeTrue("Api should not be referenced by Application");
    }
}