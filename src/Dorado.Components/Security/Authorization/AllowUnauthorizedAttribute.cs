using System;

namespace Dorado.Components.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AllowUnauthorizedAttribute : Attribute
    {
    }
}