using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Tags;

using System.Linq.Expressions;
using System.Reflection;
using Fasterflect;
using Moonfish.Cache;

namespace Moonfish.Guerilla
{
    public abstract class GuerillaBlock : IWriteQueueable
    {
        public abstract int SerializedSize { get; }

        public abstract int Alignment { get; }
        
        private delegate T ObjectActivator<out T>(params object[] args);

        private static readonly Dictionary<Type, ObjectActivator<GuerillaBlock>> Activators =
            new Dictionary<Type, ObjectActivator<GuerillaBlock>>(120);

        private static ObjectActivator<T> GetActivator<T>(ConstructorInfo ctor)
        {
            ParameterInfo[] paramsInfo = ctor.GetParameters();

            //create a single param of type object[]
            ParameterExpression param =
                Expression.Parameter(typeof (object[]), "args");

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
                Expression.Lambda(typeof (ObjectActivator<T>), newExp, param);

            //compile it
            ObjectActivator<T> compiled = (ObjectActivator<T>) lambda.Compile();
            return compiled;
        }

        public virtual T[] ReadBlockArrayData<T>(BinaryReader binaryReader, BlamPointer blamPointer)
            where T : GuerillaBlock
        {
            var array = new T[blamPointer.ElementCount];
            if (!BlamPointer.IsNull(blamPointer) && binaryReader.BaseStream.Position != blamPointer.StartAddress)
            {
                var offset = blamPointer.StartAddress - binaryReader.BaseStream.Position;
                binaryReader.BaseStream.Seek(offset, SeekOrigin.Current);
            }
            var pointerArray = new Queue<BlamPointer>[blamPointer.ElementCount];

            var ctor = GetObjectActivator<T>(typeof (T));

            for (var i = 0; i < blamPointer.ElementCount; ++i)
            {
                var element = (T) ctor();
                array[i] = element;
                pointerArray[i] = array[i].ReadFields(binaryReader);
            }
            for (var i = 0; i < blamPointer.ElementCount; ++i)
            {
                array[i].ReadInstances(binaryReader, pointerArray[i]);
            }
            return array;
        }

        private static ObjectActivator<GuerillaBlock> GetObjectActivator<T>(Type type) where T : GuerillaBlock
        {
            ObjectActivator<GuerillaBlock> ctor;
            if (Activators.TryGetValue(type, out ctor)) return ctor;

            ctor = GetActivator<T>(type.GetConstructor(Type.EmptyTypes));
            Activators[type] = ctor;
            return ctor;
        }

        public virtual byte[] ReadDataByteArray(BinaryReader binaryReader, BlamPointer blamPointer)
        {
            if (BlamPointer.IsNull(blamPointer)) return new byte[0];
            binaryReader.BaseStream.Position = blamPointer.StartAddress;
            return binaryReader.ReadBytes(blamPointer.ElementCount);
        }

        public virtual short[] ReadDataShortArray(BinaryReader binaryReader, BlamPointer blamPointer)
        {
            if (BlamPointer.IsNull(blamPointer)) return new short[0];
            binaryReader.BaseStream.Position = blamPointer.StartAddress;
            var elements = new short[blamPointer.ElementCount];
            var buffer = binaryReader.ReadBytes(blamPointer.ElementCount * 2);
            Buffer.BlockCopy(buffer, 0, elements, 0, buffer.Length);
            return elements;
        }

        public virtual Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            return new Queue<BlamPointer>();
        }

        public virtual void ReadInstances(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
        }

        public virtual void Read(BinaryReader binaryReader)
        {
            Solution.CreateLink(this, binaryReader.BaseStream as ICache);
            var pointers = ReadFields(binaryReader);
            ReadInstances(binaryReader, pointers);
        }

        public virtual int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            return nextAddress;
        }

        internal void Read_(QueueableBinaryReader queueableBinaryReader)
        {
            throw new NotImplementedException();
        }

        public virtual void QueueReads(QueueableBinaryReader queueableBinaryReader)
        {
            return;
        }

        public virtual void Write_(QueueableBinaryWriter queueableBinaryWriter)
        {
            return;
        }

        public virtual void QueueWrites(QueueableBinaryWriter binaryWriter)
        {
            //  call QueueableBinaryWriter.QueueWrite on each instance field
            //  ie; GuerillaBlock arrays, inline GuerillaBlock structs, data arrays
        }
    }
}