using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Extensions
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a random enum value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T enum value</returns>
        public static T RandomEnumValue<T>(this Random rnd)
        {
            var array = Enum.GetValues(typeof(T));
            return (T) array.GetValue(new Random().Next(array.Length));
        }
    }
}
