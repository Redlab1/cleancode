using System.Reflection;

namespace Infrastructure.Configurations;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}