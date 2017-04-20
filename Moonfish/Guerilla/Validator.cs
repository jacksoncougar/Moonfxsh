using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public class Validator
    {
        private bool error;
        private Func<BlamPointer, bool> isPointerOwnedByTagDelegate;
        private Func<BlamPointer, bool> isValidDelegate;
        private readonly List<Tuple<BlamPointer, ElementArray>> pointersList;
        private Log writeMessage;

        public Validator()
        {
            pointersList = new List<Tuple<BlamPointer, ElementArray>>();
        }

        public void Validate(TagDatum datum, Stream dataStream)
        {
            Clear();

            var offset = 0;
            var definition = new MoonfishTagGroup(Guerilla.H2Tags.First(x => x.Class == datum.Class));
            IEnumerable<MoonfishTagGroup> definitionPool = Guerilla.H2Tags.Select(x => new MoonfishTagGroup(x));
            var elementArray = CompileElementArray(definition, definitionPool, offset);
            elementArray.Count = 1;
            var binaryReader = new BlamBinaryReader(dataStream);
            var virtualTagMemory = new VirtualStreamSectionDescription(datum.VirtualAddress, datum.Length, 0);

            isValidDelegate = virtualTagMemory.Contains;
            isPointerOwnedByTagDelegate = virtualTagMemory.Contains;
            writeMessage = Console.WriteLine;

            offset = (int) dataStream.Seek(datum.VirtualAddress, SeekOrigin.Begin);

            elementArray.VirtualAddress = datum.VirtualAddress;

            ValidateTagBlock(elementArray, elementArray.ToFixedArrayPointer(), binaryReader, ref offset);

            if (error)
                OnWriteMessage($"Tag ({datum.Path}.{datum.Class.ToTokenString()})");
        }

        public bool Validate(MoonfishTagGroup validateTag, IEnumerable<MoonfishTagGroup> tagPool, string[] filenames)
        {
            Clear();

            var filename = string.Format(@"{1}\test_analysis\analysis.txt", validateTag.Class.ToTokenString(),
                Local.MapsDirectory);
            var stringWriter = File.AppendText(filename);

            writeMessage = stringWriter.WriteLine;

            var offset = 0;
            var elementArray = CompileElementArray(validateTag, tagPool, offset);

            elementArray.Count = 1;

            foreach (var file in filenames)
            {
                using (var map = new Map(file))
                {
                    var binaryReader = new BlamBinaryReader(map.BaseStream);

                    //OnWriteMessage(string.Format("Begin ({0})", map.MapName));

                    foreach (var tag in map.Index)
                    {
                        error = false;
                        if (!(tag.Class == validateTag.Class))
                            continue;

                        //var metaTableMemory = map..DefaultMemoryBlock;
                        if (tag.Class == (TagClass) "sbsp" || tag.Class == (TagClass) "ltmp")
                        {
                            //        map.StructureMemoryBlocks[map.StructureMemoryBlockBindings[tag.Identifier]];
                            map.SwitchActiveAllocation(map.StructureMemoryBlockBindings[tag.Identifier]);
                        }
                        //var virtualTagMemory = new VirtualMappedStreamSection(tag.VirtualAddress, tag.Length, 0, map);

                        //_isValidDelegate = metaTableMemory.Contains;
                        //_isPointerOwnedByTagDelegate = virtualTagMemory.Contains;
                        pointersList.Clear();

                        offset = (int) map.Seek(tag.Identifier);


                        elementArray.VirtualAddress = map.Index[tag.Identifier].VirtualAddress;
                        ValidateTagBlock(elementArray, elementArray.ToFixedArrayPointer(), binaryReader, ref offset);

                        if (error)
                            OnWriteMessage($"Tag ({tag.Path}.{validateTag.Class.ToTokenString()})");

                        stringWriter.Flush();
                    }

                    Console.WriteLine(@"Parsed ({0})", map.Header.Name);
                }
            }
            stringWriter.Close();


            return error;
        }

        /// <summary>Clears the validator back to an initial state.</summary>
        private void Clear()
        {
            error = false;
            pointersList.Clear();
        }

        private ElementArray CompileElementArray(MoonfishTagGroup tag, IEnumerable<MoonfishTagGroup> tags, int offset)
        {
            ElementArray elementArray;
            if (tag.ParentClass != TagClass.Null)
            {
                IList<MoonfishTagGroup> guerillaTagGroups = tags as IList<MoonfishTagGroup> ?? tags.ToList();
                var parentClass = guerillaTagGroups.Single(x => x.Class == tag.ParentClass);
                if (parentClass.ParentClass != TagClass.Null)
                {
                    var baseClass = guerillaTagGroups.Single(x => x.Class == parentClass.ParentClass);
                    elementArray = ProcessTagBlockDefinition(baseClass.Definition, ref offset, true);
                    elementArray.Append(ProcessTagBlockDefinition(parentClass.Definition, ref offset, true));
                    elementArray.Append(ProcessTagBlockDefinition(tag.Definition, ref offset, true));
                }
                else
                {
                    elementArray = ProcessTagBlockDefinition(parentClass.Definition, ref offset, true);
                    elementArray.Append(ProcessTagBlockDefinition(tag.Definition, ref offset, true));
                }
            }
            else
            {
                elementArray = ProcessTagBlockDefinition(tag.Definition, ref offset, true);
            }
            return elementArray;
        }

        private bool IsOwnedByTag(BlamPointer pointer)
        {
            return isPointerOwnedByTagDelegate != null && isPointerOwnedByTagDelegate(pointer);
        }

        private bool IsValid(BlamPointer pointer)
        {
            return isValidDelegate != null && isValidDelegate(pointer);
        }

        private void OnWriteMessage(string message)
        {
            writeMessage?.Invoke(message);
        }

        private void ProcessArrayFields(IList<MoonfishTagField> fields, ElementArray elementArray,
            MoonfishTagField field, ref int i, ref int offset)
        {
            if (fields[i++].Type != MoonfishFieldType.FieldArrayStart)
                throw new InvalidDataException("expected array start field");

            for (var index = 0; index < field.Count; ++index)
            {
                var startindex = i;
                ProcessFields(fields, elementArray, ref startindex, ref offset);
            }

            if (fields[i++].Type != MoonfishFieldType.FieldArrayEnd)
                throw new InvalidDataException("expected array end field");
        }

        private void ProcessFields(IList<MoonfishTagField> fields, ElementArray elementArray, ref int i, ref int offset)
        {
            for (; i < fields.Count; ++i)
            {
                var field = fields[i];
                // Check the field type.
                switch (field.Type)
                {
                    case MoonfishFieldType.FieldBlock:
                    {
                        var childElementArray = ProcessTagBlockDefinition(elementArray, field.Definition, ref offset);
                        elementArray.Children.Add(childElementArray);
                        break;
                    }
                    case MoonfishFieldType.FieldStruct:
                    {
                        var structDefinition = (MoonfishTagStruct) field.Definition;
                        var structOffset = offset;
                        IEnumerable<ElementArray> childElementArray = ProcessTagStructDefinition(elementArray,
                            structDefinition.Definition, ref structOffset);
                        elementArray.Children.AddRange(childElementArray);

                        break;
                    }
                    case MoonfishFieldType.FieldData:
                    {
                        var dataDefinition = (MoonfishTagDataDefinition) field.Definition;
                        var childElementArray = new ElementArray
                        {
                            ElementSize = ((MoonfishTagDataDefinition) field.Definition).DataElementSize,
                            Name = dataDefinition.Name,
                            Address = offset,
                            Parent = elementArray,
                            Alignment = dataDefinition.Alignment
                        };
                        elementArray.Children.Add(childElementArray);
                        break;
                    }
                    case MoonfishFieldType.FieldArrayStart:
                    {
                        ProcessArrayFields(fields, elementArray, field, ref i, ref offset);
                        break;
                    }
                    case MoonfishFieldType.FieldArrayEnd:
                    {
                        return;
                    }
                }
                offset += MoonfishTagDefinition.CalculateSizeOfField(field);
            }
        }

        private ElementArray ProcessTagBlockDefinition(MoonfishTagDefinition tagBlock, ref int offset,
            bool inline = false)
        {
            return ProcessTagBlockDefinition(null, tagBlock, ref offset, inline);
        }

        private ElementArray ProcessTagBlockDefinition(ElementArray parent, MoonfishTagDefinition tagBlock,
            ref int offset, bool inline = false)
        {
            var size = tagBlock.CalculateSizeOfFieldSet();

            var blockElementArray = new ElementArray
            {
                Name = tagBlock.Name,
                ElementSize = size,
                Address = offset,
                Parent = parent,
                MaxElementCount = tagBlock.MaximumElementCount,
                Alignment = tagBlock.Alignment
            };

            var i = 0;
            var blockOffset = inline ? offset : 0;
            ProcessFields(tagBlock.Fields, blockElementArray, ref i, ref blockOffset);
            if (inline)
                offset = blockOffset;
            return blockElementArray;
        }

        private IEnumerable<ElementArray> ProcessTagStructDefinition(ElementArray parent,
            MoonfishTagDefinition definition, ref int offset)
        {
            var size = definition.CalculateSizeOfFieldSet();

            var blockElementArray = new ElementArray
            {
                Name = definition.Name,
                ElementSize = size,
                Address = offset,
                Parent = parent,
                MaxElementCount = definition.MaximumElementCount,
                Alignment = definition.Alignment
            };

            var i = 0;
            ProcessFields(definition.Fields, blockElementArray, ref i, ref offset);
            return blockElementArray.Children;
        }

        private bool ValidateBlamPointer(BlamPointer blamPointer, ElementArray info)
        {
            var stringWriter = new StringWriter();
            if (blamPointer.ElementCount == 0 && blamPointer.StartAddress == 0)
                return true;
            if (blamPointer.ElementCount == 0 ^ blamPointer.StartAddress == 0)
                stringWriter.WriteLine("-> null-value count({0}) address({1}) is invalid", blamPointer.ElementCount,
                    blamPointer.StartAddress);
            if (blamPointer.ElementCount < 0)
                stringWriter.WriteLine("-> count({0}) is invalid", blamPointer.ElementCount);
            if (blamPointer.ElementCount > info.MaxElementCount && info.MaxElementCount > 0)
                stringWriter.WriteLine("-> count({0}) > max-count({1})", blamPointer.ElementCount, info.MaxElementCount);

            //if ( !stream.ContainsPointer( blamPointer ) )
            //    stringWriter.WriteLine( "-> address({0}) not contained in stream({1})", blamPointer.startAddress,
            //        stream.Name );

            var errors = stringWriter.ToString();
            if (!string.IsNullOrWhiteSpace(errors))
            {
                error = true;
                OnWriteMessage($"Pointer ({info.Name})\n{errors}");
                return false;
            }
            return true;
        }

        private void ValidateChildren(ElementArray elementArray, BlamBinaryReader blamBinaryReader, ref int nextAddress)
        {
            var childrenArrayPointers = (from child in elementArray.Children
                select new
                {
                    ElementArray = child,
                    ArrayPointer = new Func<BlamPointer>(() =>
                    {
                        using (blamBinaryReader.BaseStream.Pin())
                        {
                            blamBinaryReader.BaseStream.Seek(child.Address, SeekOrigin.Current);
                            var arrayPointer = blamBinaryReader.ReadBlamPointer(child.ElementSize);
                            child.VirtualAddress = arrayPointer.StartAddress;
                            child.Count = arrayPointer.ElementCount;
                            return arrayPointer;
                        }
                    })()
                }).ToList();
            foreach (var child in childrenArrayPointers)
            {
                if (!ValidateBlamPointer(child.ArrayPointer, child.ElementArray))
                    continue;
                if (!(child.ArrayPointer.ElementCount == 0 && child.ArrayPointer.StartAddress == 0))
                {
                    ValidateTagBlock(child.ElementArray, child.ArrayPointer, blamBinaryReader, ref nextAddress);
                }
            }
        }

        private void ValidateTagBlock(ElementArray info, BlamPointer pointer, BlamBinaryReader reader, ref int address)
        {
            using (reader.BaseStream.Pin())
            {
                // If owned by tag and memory has not been allocated yet*
                IEnumerable<Tuple<BlamPointer, ElementArray>> allocated = from item in pointersList
                    where item.Item1.Equals(pointer)
                    select item;
                IEnumerable<Tuple<BlamPointer, ElementArray>> partiallyAllocated = from item in pointersList
                    where item.Item1.Intersects(pointer)
                    select item;
                if (IsOwnedByTag(pointer))
                {
                    IList<Tuple<BlamPointer, ElementArray>> enumerable =
                        allocated as IList<Tuple<BlamPointer, ElementArray>> ?? allocated.ToList();
                    if (!enumerable.Any())
                    {
                        var alignedAddress = address + Padding.GetCount(address, info.Alignment);
                        if (pointer.StartAddress != alignedAddress)
                        {
                            //TODO maybe fix or remove this entire namespace...
                            if (false)
                            {
                                error = true;
                                OnWriteMessage(
                                    string.Format(
                                        "{2}: Expected address \"{0}\"  - actually was \"{1}\" delta \"{3}\"",
                                        (uint) alignedAddress, (uint) pointer.StartAddress, info.Name,
                                        alignedAddress - pointer.StartAddress));
                            }
                        }
                        address = pointer.StartAddress + pointer.PointedSize;
                    }
                    if (enumerable.Any())
                    {
                    }
                    else
                    {
                        IList<Tuple<BlamPointer, ElementArray>> overlappingItems =
                            partiallyAllocated as IList<Tuple<BlamPointer, ElementArray>> ?? partiallyAllocated.ToList();
                        if (overlappingItems.Any())
                        {
                            foreach (Tuple<BlamPointer, ElementArray> overlappingItem in overlappingItems)
                            {
                                error = true;
                                var overlap = pointer.StartAddress - overlappingItem.Item1.StartAddress -
                                              overlappingItem.Item1.PointedSize;

                                OnWriteMessage(
                                    string.Format(
                                        "Overlap of ({0})\n{3} elements sized '{5}' at '{4}'\nwith ({1})\n{6} elements sized '{8}' at '{7}'\nby ({2}) bytes",
                                        overlappingItem.Item2.ToHierarchyString(), info.ToHierarchyString(), overlap,
                                        overlappingItem.Item1.ElementCount, overlappingItem.Item1.StartAddress,
                                        overlappingItem.Item1.ElementSize, pointer.ElementCount, pointer.StartAddress,
                                        pointer.ElementSize));
                            }
                        }
                    }
                }
                else if (!IsValid(pointer))
                {
                    //error = true;
                    //OnWriteMessage(string.Format("INVALID POINTER {1} -> {0}", info.name, pointer));
                    return;
                }

                pointersList.Add(new Tuple<BlamPointer, ElementArray>(pointer, info));

                foreach (var elementAddress in pointer)
                {
                    reader.BaseStream.Position = elementAddress;
                    ValidateChildren(info, reader, ref address);
                }
            }
        }

        private delegate void Log(string message);
    }

    public class ElementArray
    {
        public readonly List<ElementArray> Children;
        public int Address;
        public int Alignment;
        public int Count;
        public int ElementSize;
        public int MaxElementCount;
        public string Name;
        public ElementArray Parent;
        public int VirtualAddress;

        public ElementArray()
        {
            Name = default(string);
            ElementSize = default(int);
            MaxElementCount = default(int);
            Count = default(int);
            Address = -1;
            Alignment = 4;
            Children = new List<ElementArray>();
            Parent = null;
        }

        private bool HasChildren
        {
            get { return Children.Count > 0 ? true : false; }
        }

        public void Append(ElementArray array)
        {
            Name = $"{Name}:{array.Name}";
            ElementSize = ElementSize + array.ElementSize;
            Alignment = array.Alignment > Alignment ? array.Alignment : Alignment;
            Children.AddRange(array.Children);
        }

        public BlamPointer ToFixedArrayPointer()
        {
            return new BlamPointer(Count, VirtualAddress, ElementSize);
        }

        public string ToHierarchyString()
        {
            if (Parent == null)
                return Name;
            return Parent.ToHierarchyString() + " -> " + Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}