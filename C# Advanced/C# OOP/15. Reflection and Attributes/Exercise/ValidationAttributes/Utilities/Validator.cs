using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attribute;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false; 
            }

            Type classType = obj.GetType();
            PropertyInfo[] properties = classType.GetProperties();

            foreach (var property in properties)
            {
                MyValidationAttribute[] attributes =
                    property.GetCustomAttributes()
                        .Where(ca => ca is MyValidationAttribute)
                        .Cast<MyValidationAttribute>()
                        .ToArray();

                foreach (var attribute in attributes)
                {
                    object propertyValue = property.GetValue(obj);

                    if (!attribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}