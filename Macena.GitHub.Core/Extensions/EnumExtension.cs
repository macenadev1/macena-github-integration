using System.ComponentModel;
using System.Reflection;

namespace Macena.GitHub.Core.Extensions
{
    /// <summary>
    /// Contem métodos de extensão para <see cref="Enum"/>.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Pega a descrição do valor de um Enum
        /// </summary>
        /// <param name="value">Enum com <see cref="DescriptionAttribute"/> descrição</param>
        /// <returns>A descrição do valor de Enum.</returns>
        public static string Description(this Enum value)
        {
            MemberInfo[] member = value.GetType().GetMember(value.ToString());
            if (member != null && member.Length != 0)
            {
                object[] customAttributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
                if (customAttributes != null && customAttributes.Length != 0)
                {
                    return ((DescriptionAttribute)customAttributes[0]).Description;
                }
            }

            return value.ToString();
        }
    }
}