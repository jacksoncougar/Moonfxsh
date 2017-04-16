using System;
using System.Collections.Generic;
using System.IO;
using Moonfish.Tags;
using System.Linq.Expressions;
using System.Reflection;

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

		public static GuerillaBlock CreateInstance(TagClass @class)
		{
			var type = @class.GetClassType();
			var ctor = GetObjectActivator<GuerillaBlock>(type);

			return ctor();
		}

        public T[] ReadBlockArrayData<T>(BinaryReader binaryReader, BlamPointer blamPointer)
            where T : GuerillaBlock
        {
			var blocks = new T[blamPointer.ElementCount];
			var pointers = new Queue<BlamPointer>[blamPointer.ElementCount];
			var ctor = GetObjectActivator<T>(typeof(T));

			if (!BlamPointer.IsNull(blamPointer) && binaryReader.BaseStream.Position != blamPointer.StartAddress)
			{
				//TODO make this work with seek.
				binaryReader.BaseStream.Position = blamPointer.StartAddress;
            }
            for (var i = 0; i < blamPointer.ElementCount; ++i)
            {
				blocks[i] = (T)ctor();
                pointers[i] = blocks[i].ReadFields(binaryReader);
            }
            for (var i = 0; i < blamPointer.ElementCount; ++i)
            {
                blocks[i].ReadInstances(binaryReader, pointers[i]);
            }

            return blocks;
        }

        private static ObjectActivator<GuerillaBlock> GetObjectActivator<T>(Type type) where T : GuerillaBlock
        {
            ObjectActivator<GuerillaBlock> ctor;

			if (!Activators.TryGetValue(type, out ctor))
			{
				ctor = GetActivator<T>(type.GetConstructor(Type.EmptyTypes));
				Activators[type] = ctor;
			}

            return ctor;
        }

        public byte[] ReadDataByteArray(BinaryReader binaryReader, BlamPointer blamPointer)
        {
			byte[] data;

			if (BlamPointer.IsNull(blamPointer))
			{
				data = new byte[0];
			}
            else
			{
				binaryReader.BaseStream.Position = blamPointer.StartAddress;

				data = binaryReader.ReadBytes(blamPointer.ElementCount);
			}

			return data;
        }

        public short[] ReadDataShortArray(BinaryReader binaryReader, BlamPointer blamPointer)
        {
			short[] data;

            if (BlamPointer.IsNull(blamPointer))
			{
				data = new short[0];
			}
			else
			{
				binaryReader.BaseStream.Position = blamPointer.StartAddress;

				data = new short[blamPointer.ElementCount];
				byte[] temp = binaryReader.ReadBytes(blamPointer.ElementCount * sizeof(short));

				Buffer.BlockCopy(temp, 0, data, 0, temp.Length);
			}
			return data;
        }

        public virtual Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            return new Queue<BlamPointer>();
        }

        public virtual void ReadInstances(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            return;
        }

        public void Read(BinaryReader binaryReader)
        {
            Queue<BlamPointer> pointers = ReadFields(binaryReader);
            ReadInstances(binaryReader, pointers);
        }

        public virtual void Write_(QueueableBinaryWriter queueableBinaryWriter)
        {
            return;
        }

        public virtual void QueueWrites(QueueableBinaryWriter binaryWriter)
        {
            return;
        }
    }
}