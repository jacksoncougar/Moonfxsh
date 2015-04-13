using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Fasterflect;
using Microsoft.CSharp;
using Moonfish.Graphics;

namespace Moonfish.Guerilla
{
    public class BinaryIO
    {
        private static Dictionary<Type, string> binaryWriterMethods;
        private static Dictionary<Type, string> binaryReaderMethods;
        public static Dictionary<Type, Delegate> binaryReaderMethodDelegates;

        public static string GetBinaryReaderMethodName( Type type )
        {
            var method = ( from m in binaryReaderMethods
                where m.Key == type
                where m.Value.ToLower( ).Contains( type.Name.Split( '.' ).Last( ).ToLower( ) )
                select m.Value ).FirstOrDefault( );
            return method;
        }

        public static string GetBinaryWriterMethodName( Type type )
        {
            var method = ( from m in binaryWriterMethods
                where m.Key == type
                where m.Value.ToLower( ).Contains( type.Name.Split( '.' ).Last( ).ToLower( ) )
                select m.Value ).FirstOrDefault( );
            return method;
        }

        private static Dictionary<Type, string> CreateMethodCache<T>( )
        {
            var totalMethods = FindAllMethods<T>( );

            var methodCache = new Dictionary<Type, string>( totalMethods.Count( ) );
            foreach ( var item in totalMethods )
            {
                methodCache[ item.ReturnType ] = item.Name;
            }
            return methodCache;
        }

        private static Dictionary<Type, Delegate> CreateMethodDelegateCache<T>( )
        {
            var totalMethods = FindAllMethods<T>( );

            var methodCache = new Dictionary<Type, Delegate>( totalMethods.Count( ) );
            foreach ( var item in totalMethods )
            {
                methodCache[ item.ReturnType ] = item.DelegateForCallMethod( );
            }
            return methodCache;
        }

        private static List<System.Reflection.MethodInfo> FindAllMethods<T>( )
        {
            var types = Assembly.GetExecutingAssembly( ).GetTypes( );
            // get BinaryReader extension methods from the executing assembly 
            var extensionMethods = ( from type in types
                where type.IsSealed && !type.IsGenericType && !type.IsNested
                from method in type.GetMethods( BindingFlags.Static
                                                | BindingFlags.Public | BindingFlags.NonPublic )
                where method.IsDefined( typeof ( ExtensionAttribute ), false )
                where method.GetParameters( )[ 0 ].ParameterType == typeof ( T )
                select method ).ToList( );

            // trim this down further to one of each return type
            extensionMethods = ( from method in extensionMethods
                group method by method.ReturnType
                into g
                select g.First( ) ).ToList( );

            var provider = new CSharpCodeProvider( );

            var methods = ( from method in typeof ( T ).GetMethods( )
                where method.ReturnType != typeof ( void )
                select method ).Where( x =>
                {
                    var typeString = provider.CreateValidIdentifier( ( x.ReturnType ).ToString( ) );
                    typeString = typeString.Split( '.' ).Last( );
                    return x.Name.ToLower( ).Contains( typeString.ToLower( ) );
                } ).ToList( );
            methods = ( from method in methods
                group method by method.ReturnType
                into g
                select g.First( ) ).ToList( );
            var totalMethods = methods.Union( extensionMethods ).ToList( );

            provider.Dispose( );
            return totalMethods;
        }

        public static void CacheMethods( )
        {
            binaryReaderMethods = CreateMethodCache<BinaryReader>( );
            binaryWriterMethods = CreateMethodCache<BinaryWriter>( );
            binaryReaderMethodDelegates = CreateMethodDelegateCache<BinaryReader>( );
        }
    }
}