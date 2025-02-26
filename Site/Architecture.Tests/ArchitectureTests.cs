using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests;

public class ArchitectureTests
{
    private const string ApplicationNamespace = "Application";
    private const string InfrastructureNamespace = "Infrastructure";
    private const string PersistenceNamespace = "Persistence";
    private const string PresentationNamespace = "Presentation";
    private const string WebNamespace = "Web";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        var assembly = Domain.Configurations.AssemblyReference.Assembly;

        var diallowedNamespaces = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PersistenceNamespace,
            PresentationNamespace,
            WebNamespace
        };

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(diallowedNamespaces)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        var assembly = Application.Configurations.AssemblyReference.Assembly;

        var diallowedNamespaces = new[]
        {
            InfrastructureNamespace,
            PersistenceNamespace,
            PresentationNamespace,
            WebNamespace
        };

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(diallowedNamespaces)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Persistence_Should_Not_HaveDependencyOnOtherProjects()
    {
        var assembly = Persistence.Configurations.AssemblyReference.Assembly;

        var diallowedNamespaces = new[]
        {
            PresentationNamespace,
            InfrastructureNamespace,
            WebNamespace
        };

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(diallowedNamespaces)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        var assembly = Infrastructure.Configurations.AssemblyReference.Assembly;

        var diallowedNamespaces = new[]
        {
            PersistenceNamespace,
            PresentationNamespace,
            WebNamespace
        };

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(diallowedNamespaces)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        var assembly = Presentation.Configurations.AssemblyReference.Assembly;

        var diallowedNamespaces = new[]
        {
            PersistenceNamespace,
            InfrastructureNamespace,
            WebNamespace
        };

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(diallowedNamespaces)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}