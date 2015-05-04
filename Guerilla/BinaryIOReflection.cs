using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Fasterflect;
using Microsoft.CSharp;

namespace Moonfish.Guerilla
{
    public class BinaryIOReflection
    {
        private static Dictionary<Type, string> _binaryWriterMethods;
        private static Dictionary<Type, string> _binaryReaderMethods;
        public static Dictionary<Type, Delegate> BinaryReaderMethodDelegates;

        public static string GetBinaryReaderMethodName(Type type)
        {
            var method = (from m in _binaryReaderMethods
                where m.Key == type
                select m.Value).FirstOrDefault();

            return method;
        }

        public static string GetBinaryWriterMethodName(Type type)
        {
            var method = (from m in _binaryWriterMethods
                where m.Key == type
                select m.Value).FirstOrDefault();
            return method;
        }

        private static Dictionary<Type, string> CreateMethodCache<T>()
        {
            var totalMethods = FindAllMethods<T>();

            var methodCache = new Dictionary<Type, string>(totalMethods.Count());
            foreach (var item in totalMethods)
            {
                methodCache[item.ReturnType] = item.Name;
            }
            return methodCache;
        }

        private static Dictionary<Type, Delegate> CreateMethodDelegateCache<T>()
        {
            var totalMethods = FindAllMethods<T>();

            var methodCache = new Dictionary<Type, Delegate>(totalMethods.Count());
            foreach (var item in totalMethods)
            {
                methodCache[item.ReturnType] = item.DelegateForCallMethod();
            }
            return methodCache;
        }

        private static List<MethodInfo> FindAllMethods<T>()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            // get BinaryReader extension methods from the executing assembly 
            var extensionMethods = (from type in types
                where type.IsSealed && !type.IsGenericType && !type.IsNested
                from method in type.GetMethods(BindingFlags.Static
                                               | BindingFlags.Public | BindingFlags.NonPublic)
                where method.IsDefined(typeof (ExtensionAttribute), false)
                where method.GetParameters()[0].ParameterType == typeof (T)
                select method).ToList();

            // trim this down further to one of each return type
            extensionMethods = (from method in extensionMethods
                group method by method.ReturnType
                into g
                select g.First()).ToList();

            var provider = new CSharpCodeProvider();

            var methods = (from method in typeof (T).GetMethods()
                where method.ReturnType != typeof (void)
                select method).Where(x =>
                {
                    var typeString = provider.CreateValidIdentifier((x.ReturnType).ToString());
                    typeString = typeString.Split('.').Last();
                    return x.Name.ToLower().Contains(typeString.ToLower());
                }).ToList();
            methods = (from method in methods
                group method by method.ReturnType
                into g
                select g.First()).ToList();
            var totalMethods = methods.Union(extensionMethods).ToList();

            provider.Dispose();
            return totalMethods;
        }

        public static void CacheMethods()
        {
            _binaryReaderMethods = CreateMethodCache<BinaryReader>();
            _binaryWriterMethods = CreateMethodCache<BinaryWriter>();
            BinaryReaderMethodDelegates = CreateMethodDelegateCache<BinaryReader>();
        }
    }
}