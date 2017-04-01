using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Cache;
using Moonfish.Tags;


namespace Moonfish.Guerilla
{
    public class Validator
    {
        private Func<BlamPointer, bool> _isPointerOwnedByTagDelegate;
        private Func<BlamPointer, bool> _isValidDelegate;
        private List<Tuple<BlamPointer, ElementArray>> _pointersList;
        private Log _writeMessage;

        private bool error;

        public void Validate(TagDatum datum, Stream dataStream)
        {
            error = false;

            _pointersList = new List<Tuple<BlamPointer, ElementArray>>();
            _writeMessage = Console.WriteLine;

            var offset = 0;

            var definition =
                new MoonfishTagGroup(Guerilla.h2Tags.First(x => x.Class == datum.Class));
            var definitionPool = Guerilla.h2Tags.Select(x => new MoonfishTagGroup(x));

            var elementArray = CompileElementArray(definition, definitionPool, offset);

            elementArray.count = 1;

            var binaryReader = new BinaryReader(dataStream);

            var virtualTagMemory = new VirtualMappedAddress
            {
                Address = datum.VirtualAddress,
                Length = datum.Length
            };

            _isValidDelegate = virtualTagMemory.Contains;
            _isPointerOwnedByTagDelegate = virtualTagMemory.Contains;

            offset = (int) dataStream.Seek(datum.VirtualAddress, SeekOrigin.Begin);

            elementArray.virtualAddress = datum.VirtualAddress;

			ValidateTagBlock(elementArray, elementArray.ToFixedArrayPointer(), binaryReader, ref offset);

            if (error)
                OnWriteMessage(string.Format("Tag ({0}.{1})", datum.Path, datum.Class.ToTokenString()));
        }

        public bool Validate(MoonfishTagGroup validateTag, IEnumerable<MoonfishTagGroup> tagPool, string[] filenames)
        {
            error = false;
            _pointersList = new List<Tuple<BlamPointer, ElementArray>>();
            var filename = string.Format(@"{1}\test_analysis\analysis.txt",
                validateTag.Class.ToTokenString(), Local.MapsDirectory);
            var stringWriter = File.AppendText(filename);

            _writeMessage = (stringWriter.WriteLine);

            var offset = 0;
            var elementArray = CompileElementArray(validateTag, tagPool, offset);

            elementArray.count = 1;

            foreach (var file in filenames)
            {
                using (var map = new CacheStream(file))
                {
                    var binaryReader = new BinaryReader(map);

                    //OnWriteMessage(string.Format("Begin ({0})", map.MapName));

                    foreach (var tag in map.Index)
                    {
                        error = false;
                        if (!(tag.Class == validateTag.Class)) continue;

                        var metaTableMemory = map.DefaultMemoryBlock;
                        if (tag.Class == (TagClass)"sbsp" || tag.Class == (TagClass)"ltmp")
                        {
                            metaTableMemory =
                                map.StructureMemoryBlocks[map.StructureMemoryBlockBindings[tag.Identifier]];
                            map.ActiveAllocation(StructureCache.VirtualStructureCache0 +
                                                 map.StructureMemoryBlockBindings[tag.Identifier]);
                        }
                        var virtualTagMemory = new VirtualMappedAddress
                        {
                            Address = tag.VirtualAddress,
                            Length = tag.Length
                        };

                        _isValidDelegate = metaTableMemory.Contains;
                        _isPointerOwnedByTagDelegate = virtualTagMemory.Contains;
                        _pointersList.Clear();

                        offset = (int) map.Seek(tag.Identifier);


                        elementArray.virtualAddress = map.Index[tag.Identifier].VirtualAddress;
                        ValidateTagBlock(elementArray, elementArray.ToFixedArrayPointer(), binaryReader, ref offset);

                        if (error)
                            OnWriteMessage(string.Format("Tag ({0}.{1})", tag.Path, validateTag.Class.ToTokenString()));

                        stringWriter.Flush();
                    }

                    Console.WriteLine(@"Parsed ({0})", map.Header.Name);
                }
            }
            stringWriter.Close();


            return error;
        }

        private ElementArray CompileElementArray(MoonfishTagGroup tag, IEnumerable<MoonfishTagGroup> tags, int offset)
        {
            ElementArray elementArray;
            if (tag.ParentClass != TagClass.Null)
            {
                var guerillaTagGroups = tags as IList<MoonfishTagGroup> ?? tags.ToList();
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
            return _isPointerOwnedByTagDelegate != null && _isPointerOwnedByTagDelegate(pointer);
        }

        private bool IsValid(BlamPointer pointer)
        {
            return _isValidDelegate != null && _isValidDelegate(pointer);
        }

        private void OnWriteMessage(string message)
        {
            if (_writeMessage != null) _writeMessage(message);
        }

        private void ProcessArrayFields(IList<MoonfishTagField> fields, ElementArray elementArray,
            MoonfishTagField field, ref int i, ref int offset)
        {
            var name = field.Strings;
            ++i; //move past field_type._field_array_start
            for (var index = 0; index < field.Count; ++index)
            {
                var startindex = i;
                ProcessFields(fields, elementArray, ref startindex, ref offset);
            }
            ++i; // move past field_type._field_array_end
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
                        elementArray.children.Add(childElementArray);
                        break;
                    }
                    case MoonfishFieldType.FieldStruct:
                    {
                        var struct_definition = (MoonfishTagStruct) field.Definition;
                        var structOffset = offset;
                        var childElementArray = ProcessTagStructDefinition(elementArray, struct_definition.Definition,
                            ref structOffset);
                        elementArray.children.AddRange(childElementArray);

                        break;
                    }
                    case MoonfishFieldType.FieldData:
                    {
                        var data_definition = (MoonfishTagDataDefinition) field.Definition;
                        var childElementArray = new ElementArray
                        {
                            elementSize = ((MoonfishTagDataDefinition) field.Definition).DataElementSize,
                            name = data_definition.Name,
                            address = offset,
                            parent = elementArray,
                            alignment = data_definition.Alignment
                        };
                        elementArray.children.Add(childElementArray);
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
                name = tagBlock.Name,
                elementSize = size,
                address = offset,
                parent = parent,
                maxElementCount = tagBlock.MaximumElementCount,
                alignment = tagBlock.Alignment
            };

            var i = 0;
            var blockOffset = inline ? offset : 0;
            ProcessFields(tagBlock.Fields, blockElementArray, ref i, ref blockOffset);
            if (inline) offset = blockOffset;
            return blockElementArray;
        }

        private IEnumerable<ElementArray> ProcessTagStructDefinition(ElementArray parent,
            MoonfishTagDefinition definition, ref int offset)
        {
            var size = definition.CalculateSizeOfFieldSet();

            var blockElementArray = new ElementArray
            {
                name = definition.Name,
                elementSize = size,
                address = offset,
                parent = parent,
                maxElementCount = definition.MaximumElementCount,
                alignment = definition.Alignment
            };

            var i = 0;
            ProcessFields(definition.Fields, blockElementArray, ref i, ref offset);
            return blockElementArray.children;
        }

        private bool ValidateBlamPointer(BlamPointer blamPointer, ElementArray info)
        {
            var stringWriter = new StringWriter();
            if (blamPointer.ElementCount == 0 && blamPointer.StartAddress == 0) return true;
            if (blamPointer.ElementCount == 0 ^ blamPointer.StartAddress == 0)
                stringWriter.WriteLine("-> null-value count({0}) address({1}) is invalid", blamPointer.ElementCount,
                    blamPointer.StartAddress);
            if (blamPointer.ElementCount < 0)
                stringWriter.WriteLine("-> count({0}) is invalid", blamPointer.ElementCount);
            if (blamPointer.ElementCount > info.maxElementCount && info.maxElementCount > 0)
                stringWriter.WriteLine("-> count({0}) > max-count({1})", blamPointer.ElementCount, info.maxElementCount);

            //if ( !stream.ContainsPointer( blamPointer ) )
            //    stringWriter.WriteLine( "-> address({0}) not contained in stream({1})", blamPointer.startAddress,
            //        stream.Name );

            var errors = stringWriter.ToString();
            if (!string.IsNullOrWhiteSpace(errors))
            {
                error = true;
                OnWriteMessage(string.Format("Pointer ({0})\n{1}", info.name, errors));
                return false;
            }
            return true;
        }

        private void ValidateChildren(ElementArray elementArray, BinaryReader binaryReader, ref int nextAddress)
        {
            var childrenArrayPointers = (from child in elementArray.children
                select new
                {
                    ElementArray = child,
                    ArrayPointer = new Func<BlamPointer>(() =>
                    {
                        using (binaryReader.BaseStream.Pin())
                        {
                            binaryReader.BaseStream.Seek(child.address, SeekOrigin.Current);
                            var arrayPointer = binaryReader.ReadBlamPointer(child.elementSize);
                            child.virtualAddress = arrayPointer.StartAddress;
                            child.count = arrayPointer.ElementCount;
                            return arrayPointer;
                        }
                    })()
                }).ToList();
            foreach (var child in childrenArrayPointers)
            {
                if (
                    !ValidateBlamPointer(child.ArrayPointer, child.ElementArray))
                    continue;
                if (!(child.ArrayPointer.ElementCount == 0 && child.ArrayPointer.StartAddress == 0))
                {
                    ValidateTagBlock(child.ElementArray, child.ArrayPointer, binaryReader, ref nextAddress);
                }
            }
        }

        private void ValidateTagBlock(ElementArray info, BlamPointer pointer, BinaryReader reader, ref int address)
        {
            using (reader.BaseStream.Pin())
            {
                // If owned by tag and memory has not been allocated yet*
                var allocated = from item in _pointersList
                    where item.Item1.Equals(pointer)
                    select item;
                var partiallyAllocated = from item in _pointersList
                    where item.Item1.Intersects(pointer)
                    select item;
                if (IsOwnedByTag(pointer))
                {
                    var enumerable = allocated as IList<Tuple<BlamPointer, ElementArray>> ?? allocated.ToList();
                    if (!enumerable.Any())
                    {
                        var alignedAddress = (address) +
                                             Padding.GetCount(address, info.alignment);
                        if (pointer.StartAddress != alignedAddress)
                        {
                            var mapStream = reader.BaseStream as CacheStream;
                            if (mapStream != null)
                            {
                                error = true;
                                OnWriteMessage(string.Format("{2}: Expected address \"{0}\"  - actually was \"{1}\" delta \"{3}\"",
                                    (uint)alignedAddress, (uint)pointer.StartAddress, info.name, alignedAddress - pointer.StartAddress));
                            }
                        }
                        address = pointer.StartAddress + pointer.PointedSize;
                    }
                    if (enumerable.Any())
                    {
                    }
                    else
                    {
                        var overlappingItems = partiallyAllocated as IList<Tuple<BlamPointer, ElementArray>> ??
                                               partiallyAllocated.ToList();
                        if (overlappingItems.Any())
                        {
                            foreach (var overlappingItem in overlappingItems)
                            {
                                error = true;
                                var overlap = pointer.StartAddress - overlappingItem.Item1.StartAddress -
                                              overlappingItem.Item1.PointedSize;

                                OnWriteMessage(
                                    string.Format(
                                        "Overlap of ({0})\n{3} elements sized '{5}' at '{4}'\nwith ({1})\n{6} elements sized '{8}' at '{7}'\nby ({2}) bytes",
                                        overlappingItem.Item2.ToHierarchyString(), info.ToHierarchyString(), overlap,
                                        overlappingItem.Item1.ElementCount, overlappingItem.Item1.StartAddress,
                                        overlappingItem.Item1.ElementSize,
                                        pointer.ElementCount, pointer.StartAddress, pointer.ElementSize));
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
                else
                {
                    // OnWriteMessage( string.Format( "EXTERNAL SHARE" ) );
                }

                _pointersList.Add(new Tuple<BlamPointer, ElementArray>(pointer, info));

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
        public readonly List<ElementArray> children;
        public int address;
        public int alignment;
        public int count;
        public int elementSize;
        public int maxElementCount;
        public string name;
        public ElementArray parent;
        public int virtualAddress;

        public ElementArray()
        {
            name = default(string);
            elementSize = default(int);
            maxElementCount = default(int);
            count = default(int);
            address = -1;
            alignment = 4;
            children = new List<ElementArray>();
            parent = null;
        }

        public bool HasChildren
        {
            get { return children.Count > 0 ? true : false; }
        }

        public void Append(ElementArray array)
        {
            name = string.Format("{0}:{1}", name, array.name);
            elementSize = elementSize + array.elementSize;
            alignment = array.alignment > alignment ? array.alignment : alignment;
            children.AddRange(array.children);
        }

        public BlamPointer ToFixedArrayPointer()
        {
            return new BlamPointer(count, virtualAddress, elementSize);
        }

        public string ToHierarchyString()
        {
            if (parent == null)
                return name;
            return parent.ToHierarchyString() + " -> " + name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}