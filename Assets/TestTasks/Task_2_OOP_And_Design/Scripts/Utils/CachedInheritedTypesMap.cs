using System;
using System.Collections.Generic;
using System.Reflection;

namespace TestTasks.Task_2_OOP_And_Design.Scripts.Utils
{
    /// <summary>
    /// Where T - is concrete class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class CachedInheritedTypesMap<T> where T : class
    {
        public static IReadOnlyDictionary<string, Type> items { get; }

        private static readonly string NULL_OBJECT_LABEL = "Null";

        static CachedInheritedTypesMap()
        {
            var classType = typeof(T);
            var assembly = Assembly.GetAssembly(classType);
            var allTypes = assembly.GetTypes();

            var dc  = new Dictionary<string, Type>();
            foreach (var type in allTypes)
            {
                bool isCanBeAdded = type.IsClass && !type.IsAbstract && type.IsSubclassOf(classType) && !type.Name.Contains(NULL_OBJECT_LABEL);
                if (isCanBeAdded)
                {
                    dc.Add(type.Name, type);   
                }
            }
            
            items = dc;
        }
        
    }
}