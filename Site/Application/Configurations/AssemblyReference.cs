﻿using System.Reflection;

namespace Application.Configurations;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}