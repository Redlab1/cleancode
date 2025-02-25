using System.Reflection;

namespace Domain.Configurations;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}