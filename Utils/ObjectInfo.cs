using System;
using System.Linq;
using System.Reflection;

namespace ElPalacio.Domain.Utils
{
    public class ObjectInfo
    {
        /// <summary>
        /// Listed of the types of properties you can analyze.
        /// </summary>
        public enum FeatureEnum
        {
            Interface = 1,
            Property = 2
        }

        /// <summary>
        /// Method that determines whether the object has the indicated property.
        /// </summary>
        /// <param name="objType">Object to analyze</param>
        /// <param name="featureEnum">Type of property to look for</param>
        /// <param name="featureName">Name of the property to look for in the object.</param>
        /// <returns>[bool] Boolean value that determines whether the provided property was found.</returns>
        public static bool HasFeature(Type objType, FeatureEnum featureEnum, string featureName)
        {
            bool result = false;
            featureName = featureName.ToLower();
            switch (featureEnum)
            {
                case FeatureEnum.Interface:
                    Type[] interfaces = objType.GetInterfaces();
                    result = interfaces.Any(x => x.Name.ToLower().Contains(featureName));
                    break;
                case FeatureEnum.Property:
                    PropertyInfo[] properties = objType.GetProperties();
                    result = properties.Any(x => x.Name.ToLower().Contains(featureName));
                    break;
            }

            return result;
        }
    }
}