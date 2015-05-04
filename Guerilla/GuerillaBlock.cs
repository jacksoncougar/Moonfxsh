using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Tags;
using Moonfish.Tags.BlamExtension;
using System.Linq.Expressions;
using System.Reflection;

namespace Moonfish.Guerilla
{
    public abstract class GuerillaBlock
    {
        public abstract int SerializedSize { get; }

        public abstract int Alignment { get; }

        protected GuerillaBlock()
        {
        }

        protected GuerillaBlock(BinaryReader binaryReader)
        {
        }

        public static BlamPointer ReadBlockArrayPointer<T>(BinaryReader binaryReader)
            where T : GuerillaBlock, new()
        {
            var ctor = GetObjectActivator<T>(typeof(T));
            var elementSize = ctor().SerializedSize;
            return ReadBlockArrayPointer(binaryReader, elementSize);
        }

        public static BlamPointer ReadBlockArrayPointer(BinaryReader binaryReader, int elementSize)
        {
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            return blamPointer;
        }

        delegate T ObjectActivator<out T>(params object[] args);

        static readonly Dictionary<Type, ObjectActivator<GuerillaBlock>> Activators = new Dictionary<Type, ObjectActivator<GuerillaBlock>>(120);

        static ObjectActivator<T> GetActivator<T> (ConstructorInfo ctor)
        {
            Type type = ctor.DeclaringType;
            ParameterInfo[] paramsInfo = ctor.GetParameters();

            //create a single param of type object[]
            ParameterExpression param =
                Expression.Parameter(typeof(object[]), "args");

            Expression[] argsExp =
                new Expression[paramsInfo.Length];

            //pick each arg from the params array 
            //and create a typed expression of them
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp =
                    Expression.ArrayIndex(param, index);

                Expression paramCastExp =
                    Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            NewExpression newExp = Expression.New(ctor, argsExp);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            LambdaExpression lambda =
                Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            //compile it
            ObjectActivator<T> compiled = (ObjectActivator<T>)lambda.Compile();
            return compiled;
        }

        public static T[] ReadBlockArrayData<T>(BinaryReader binaryReader, BlamPointer blamPointer)
            where T : GuerillaBlock, new()
        {
            var array = new T[blamPointer.ElementCount];
            binaryReader.BaseStream.Position = blamPointer.StartAddress;
            var pointerArray = new Queue<BlamPointer>[blamPointer.ElementCount];

            var ctor = GetObjectActivator<T>(typeof(T));

            for (var i = 0; i < blamPointer.ElementCount; ++i)
            {
                array[i] = (T)ctor();
                pointerArray[i] = array[i].ReadFields(binaryReader);
            }
            for (var i = 0; i < blamPointer.ElementCount; ++i)
            {
                array[i].ReadPointers(binaryReader, pointerArray[i]);
            }
            return array;
        }

        private static ObjectActivator<GuerillaBlock> GetObjectActivator<T>(Type type) where T : GuerillaBlock, new()
        {
            ObjectActivator<GuerillaBlock> ctor;
            if (Activators.TryGetValue(type, out ctor)) return ctor;

            ctor = GetActivator<T>(type.GetConstructor(Type.EmptyTypes));
            Activators[type] = ctor;
            return ctor;
        }

        public static byte[] ReadDataByteArray(BinaryReader binaryReader, BlamPointer blamPointer)
        {
            binaryReader.BaseStream.Position = blamPointer.StartAddress;
            return binaryReader.ReadBytes(blamPointer.ElementCount);
        }

        public static short[] ReadDataShortArray(BinaryReader binaryReader, BlamPointer blamPointer)
        {
            binaryReader.BaseStream.Position = blamPointer.StartAddress;
            var elements = new short[blamPointer.ElementCount];
            var buffer = binaryReader.ReadBytes(blamPointer.ElementCount*2);
            Buffer.BlockCopy(buffer, 0, elements, 0, buffer.Length);
            return elements;
        }

        public virtual Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            return new Queue<BlamPointer>();
        }

        public virtual void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
        }

        public virtual void Read(BinaryReader binaryReader)
        {
            var pointers = ReadFields(binaryReader);
            ReadPointers(binaryReader, pointers);
        }

        public virtual int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            return nextAddress;
        }
    }
}