using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoMapper
{
    
    public static class Mapper
    {
        /// <summary>
        /// Execute a mapping from the source object to a new or existed destination object with supplied mapping options.
        /// </summary>
        /// <typeparam name="T">Type of the destination object</typeparam>
        /// <param name="toMapping">Sourse object</param>
        /// <param name="destObject">Destination object.If not existed, it willbe create new instance</param>
        /// <param name="ignoredProperties">Array of ignored properties, if need</param>
        /// <returns>Object with mapping properties</returns>
        public static T Mapping<T>(
            object toMapping, 
            T destObject = default(T),
            string[] ignoredProperties = null
            ) where T : new()
        {
            List<PropertyInfo> propList;           
            if (ignoredProperties == null)
            {
                propList = toMapping.GetType().GetProperties().ToList(); 
            }
            else
            {                               
                propList = toMapping.GetType().GetProperties().Where(
                    propertyInfo => !ignoredProperties.Contains(propertyInfo.Name)
                    ).ToList();                
            }
            if (propList.Count == 0)
            {
                return destObject;
            }
            if (destObject == null)
            {
                destObject = new T();
            }
            var propListResult = destObject.GetType().GetProperties().ToList();           
            foreach (var prop in propList)
            {
                try
                {
                    if(!prop.PropertyType.IsPrimitive)
                    {
                        var instance = Activator.CreateInstance(prop.PropertyType);
                        instance = prop.GetValue(toMapping);
                        destObject = Mapping(instance, destObject, ignoredProperties);
                    }
                }
                catch (Exception)
                {                   
                }
                var prop1 = prop;
                foreach (var propertyInfo in propListResult.Where(
                    propertyInfo => (
                        string.Equals(
                            prop1.Name,
                            propertyInfo.Name,
                            StringComparison.CurrentCultureIgnoreCase
                            )
                        && prop1.PropertyType == propertyInfo.PropertyType                        
                        )
                    )
                    )
                {
                    destObject.GetType().GetProperty(propertyInfo.Name).SetValue(
                        destObject,
                        prop.GetValue(toMapping)
                        );
                }
            }
            return destObject;
        }       
    }
}
