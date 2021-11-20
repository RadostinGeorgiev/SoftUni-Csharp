using System;

namespace ValidationAttributes.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class MyValidationAttribute : System.Attribute
    {
        public abstract bool IsValid(object obj);
    }
}