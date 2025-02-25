using System.Reflection;

namespace Presentation.Configurations;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}