using System.ComponentModel;
using System.Reflection;

namespace Library.ApplicationCore.Enums;

public static class EnumHelper
{
    public static string GetDescription(Enum value)
    {
        if (value == null)
            return string.Empty;

        FieldInfo fieldInfo = value.GetType().GetField(value.ToString())!;

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        else
        {
            return value.ToString();
        }
    }
}