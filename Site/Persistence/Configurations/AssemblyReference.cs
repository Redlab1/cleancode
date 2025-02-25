using System.Reflection;

namespace Persistence.Configurations;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}