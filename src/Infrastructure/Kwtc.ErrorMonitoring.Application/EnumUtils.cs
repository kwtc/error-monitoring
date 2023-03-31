namespace Kwtc.ErrorMonitoring.Application;

using System.ComponentModel;

public static class EnumUtils
{
    public static T GetValueFromDescription<T>(string description) where T : Enum
    {
        foreach (var field in typeof(T).GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                if (attribute.Description == description)
                {
                    return (T)field.GetValue(null)!;
                }
            }
            else
            {
                if (field.Name == description)
                {
                    return (T)field.GetValue(null)!;
                }
            }
        }

        throw new ArgumentException($"Unable to find conversion from {typeof(T)} value {description}.", nameof(description));
    }
}
