using System;

namespace FruityFramework.Core
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns a random element from an emum if the element is Random
        /// </summary>
        /// <param name="enumValue"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CheckForRandom<T>(this T enumValue)
        {
            while (enumValue.ToString().Equals("Random"))
            {
                var values = Enum.GetValues(typeof(T));
                var random = new Random();
                enumValue = (T)values.GetValue(random.Next(values.Length));
            }
            return enumValue;
        }
    }
}
