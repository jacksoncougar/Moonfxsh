using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Fasterflect;
using Microsoft.CSharp;

namespace Moonfish.Guerilla
{
    public static class BinaryIOReflection
    {
        private static Dictionary<Type, string> binaryWriterMethods;
        private static Dictionary<Type, string> binaryReaderMethods;
        public static Dictionary<Type, Delegate> BinaryReaderMethodDelegates;

        public static string GetBinaryReaderMethodName(Type type)
        {
            var method = (from m in binaryReaderMethods where m.Key == type select m.Value).FirstOrDefault();

            return method;
        }

        public static string GetBinaryWriterMethodName(Type type)
        {
            var method = (from m in binaryWriterMethods where m.Key == type select m.Value).FirstOrDefault();
            return method;
        }

        private static Dictionary<Type, string> CreateMethodCache<T>()
        {
            List<MethodInfo> totalMethods = FindAllMethods<T>();

            var methodCache = new Dictionary<Type, string>(totalMethods.Count);
            foreach (var item in totalMethods)
            {
                methodCache[item.ReturnType] = item.Name;
            }
            return methodCache;
        }

        private static Dictionary<Type, string> CreateWriteMethodCache<T>()
        {
            List<MethodInfo> totalMethods = FindAllMethodsByReturnValue<T>();

            var methodCache = new Dictionary<Type, string>(totalMethods.Count());
            foreach (var item in totalMethods)
            {
                IList<ParameterInfo> parameters = item.Parameters();
                methodCache[parameters.Count > 1 ? parameters[1].ParameterType : parameters[0].ParameterType] =
                    item.Name;
            }
            return methodCache;
        }

        private static Dictionary<Type, Delegate> CreateMethodDelegateCache<T>()
        {
            List<MethodInfo> totalMethods = FindAllMethods<T>();

            var methodCache = new Dictionary<Type, Delegate>(totalMethods.Count());
            foreach (var item in totalMethods)
            {
                methodCache[item.ReturnType] = item.DelegateForCallMethod();
            }
            return methodCache;
        }

        private static List<MethodInfo> FindAllMethodsByReturnValue<T>()
        {
            Type[] types;

            try
            {
                types = Assembly.GetExecutingAssembly().GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(item => item != null).ToArray();
            }
            // get BinaryReader extension methods from the executing assembly 
            List<MethodInfo> extensionMethods = (from type in types
                where type.IsSealed && !type.IsGenericType && !type.IsNested
                from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                where method.IsDefined(typeof (ExtensionAttribute), false)
                where method.ReturnType == typeof (void)
                where method.Name == "Write"
                where method.Parameters().Count > 1 && method.Parameters()[0].ParameterType == typeof (T)
                select method).ToList();

            // trim this down further to one of each return type
            extensionMethods =
                (from method in extensionMethods
                    group method by method.Parameters()[1].ParameterType
                    into g select g.First()).ToList();

            var provider = new CSharpCodeProvider();

            List<MethodInfo> methods = (from method in typeof (T).GetMethods()
                where method.ReturnType == typeof (void)
                where method.Parameters().Count > 0
                where method.Name == "Write"
                select method).ToList();
            methods =
                (from method in methods group method by method.Parameters()[0].ParameterType into g select g.First())
                    .ToList();
            List<MethodInfo> totalMethods = methods.Union(extensionMethods).ToList();

            provider.Dispose();
            return totalMethods;
        }

        private static List<MethodInfo> FindAllMethods<T>()
        {
            Type[] types;
            try
            {
                types = Assembly.GetExecutingAssembly().GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(item => item != null).ToArray();
            }
            // get BinaryReader extension methods from the executing assembly 
            List<MethodInfo> extensionMethods = (from type in types
                where type.IsSealed && !type.IsGenericType && !type.IsNested
                from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                where method.IsDefined(typeof (ExtensionAttribute), false)
                where method.GetParameters()[0].ParameterType == typeof (T)
                select method).ToList();

            // trim this down further to one of each return type
            extensionMethods =
                (from method in extensionMethods group method by method.ReturnType into g select g.First()).ToList();

            var provider = new CSharpCodeProvider();

            List<MethodInfo> methods =
                (from method in typeof (T).GetMethods() where method.ReturnType != typeof (void) select method).Where(
                    x =>
                    {
                        var typeString = provider.CreateValidIdentifier(x.ReturnType.ToString());
                        typeString = typeString.Split('.').Last();
                        return x.Name.ToLower().Contains(typeString.ToLower());
                    }).ToList();
            methods = (from method in methods group method by method.ReturnType into g select g.First()).ToList();
            List<MethodInfo> totalMethods = methods.Union(extensionMethods).ToList();

            provider.Dispose();
            return totalMethods;
        }

        public static void CacheMethods()
        {
            binaryReaderMethods = CreateMethodCache<BlamBinaryReader>();
            binaryWriterMethods = CreateWriteMethodCache<BlamBinaryWriter>();
            BinaryReaderMethodDelegates = CreateMethodDelegateCache<BlamBinaryReader>();
        }
    };
}