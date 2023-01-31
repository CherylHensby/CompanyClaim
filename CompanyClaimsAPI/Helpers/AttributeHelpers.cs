using CompanyClaimsAPI.Models;
using System.ComponentModel;
using System.Reflection;

namespace CompanyClaimsAPI.Helpers
{
    public static class AttributeHelpers
    {

        public static string GetEnumDescription(ClaimTypeEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
