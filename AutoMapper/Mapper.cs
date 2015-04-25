using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace AutoMapper
{
    
    public static class Mapper
    {
        public static T Mapping<T>(
            object toMapping, 
            T result = default(T),
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
                return result;
            }
            if (result == null)
            {
                result = new T();
            }
            var propListResult = result.GetType().GetProperties().ToList();           
            foreach (var prop in propList)
            {
                try
                {
                    if(!prop.PropertyType.IsPrimitive)
                    {
                        var instance = Activator.CreateInstance(prop.PropertyType);
                        instance = prop.GetValue(toMapping);
                        result = Mapping(instance, result, ignoredProperties);
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
                    result.GetType().GetProperty(propertyInfo.Name).SetValue(
                        result,
                        prop.GetValue(toMapping)
                        );
                }
            }
            return result;
        }       
    }
}
