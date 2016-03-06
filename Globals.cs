using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Moonfish.Cache;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.ResourceManagement;
using Moonfish.Tags;

namespace Moonfish
{
    /// <summary>
    ///     This static class holds all globals for Halo 2 and useful methods
    ///     This isn't actuall how the enum is setup in Halo 2: I'm just inserting an extra flag
    /// </summary>
    public static class Halo2
    {
        public enum ResourceSource
        {
            Local = 0,
            Tag = 1,
            MainMenu = 2,
            Shared = 4,
            SinglePlayerShared = 6
        }

        public const int NullPtr = 0;
        private static CacheStream mapStream;
        private static CacheStream resourceShared;
        private static CacheStream resourceSinglePlayer;
        private static CacheStream resourceMainMenu;
        private static readonly TagGroupLookup tagGroups = new TagGroupLookup();
        private static readonly GlobalStrings strings = new GlobalStrings();
        private static readonly Dictionary<TagClass, Type> definedTagGroupsDictionary;

        static Halo2()
        {
            Paths = new GlobalPaths();
            definedTagGroupsDictionary = new Dictionary<TagClass, Type>(3);
            var assembly = typeof (TagClass).Assembly;
            if (assembly == null) throw new ArgumentNullException("assembly");
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null).ToArray();
            }
            foreach (var type in types.Where(x => x.IsDefined(typeof (TagClassAttribute), false)))
            {
                var tagClassAttribute = type.GetCustomAttributes(typeof (TagClassAttribute), false)[0] as
                    TagClassAttribute;
                if (tagClassAttribute == null) continue;
                definedTagGroupsDictionary.Add(tagClassAttribute.TagClass, type);
            }
        }

        /// <summary>
        ///     A list of each tag_type used in halo 2's retail maps
        /// </summary>
        public static TagGroupLookup Classes
        {
            get { return tagGroups; }
        }

        /// <summary>
        ///     A list of all standard strings in Halo 2
        /// </summary>
        public static GlobalStrings Strings
        {
            get { return strings; }
        }

        public static GlobalPaths Paths { get; set; }

        public static MapType CheckMapType(string filename)
        {
            using (
                var reader =
                    new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite,
                        2048, FileOptions.SequentialScan | FileOptions.Asynchronous)))
            {
                reader.BaseStream.Seek(320, SeekOrigin.Begin);
                return (MapType) reader.ReadInt32();
            }
        }

        public static dynamic GetReferenceObject(TagIdent identifier, bool reload = false)
        {
            if ( mapStream == null || identifier == TagIdent.NullIdentifier ) return null;
            if (reload)
                mapStream.ClearCache(identifier);
            return mapStream.Deserialize(identifier);
        }

        public static dynamic GetReferenceObject(TagReference reference)
        {
            if (mapStream == null) return null;
            if (reference.Ident == TagIdent.NullIdentifier) return null;

            try
            {
                var @object = mapStream.Deserialize(reference.Ident);
                return @object;
            }
            catch
            {
                return null;
            }
        }

        public static T GetReferenceObject<T>(TagReference reference) where T : GuerillaBlock
        {
            if (mapStream == null) return null;
            if (reference.Ident == TagIdent.NullIdentifier) return null;

            return (T) mapStream.Deserialize(reference.Ident);
        }

        public static ResourceStream GetResourceBlock(GlobalGeometryBlockInfoStructBlock blockInfo)
        {
            Stream resourceStream = mapStream;
            if (blockInfo.ResourceLocation != ResourceSource.Local
                && !TryGettingResourceStream(blockInfo.BlockOffset, out resourceStream))
                return null;
            resourceStream.Position = blockInfo.ResourceOffset + 8;
            var buffer = new byte[blockInfo.BlockSize - 8];
            resourceStream.Read(buffer, 0, blockInfo.BlockSize - 8);
            return new ResourceStream(buffer, blockInfo);
        }

        public static bool LoadResource(CacheStream map)
        {
            switch (map.Header.Type)
            {
                case MapType.Shared:
                    resourceShared = map;
                    return true;
                case MapType.SinglePlayerShared:
                    resourceSinglePlayer = map;
                    return true;
                case MapType.MainMenu:
                    resourceMainMenu = map;
                    return true;
                default:
                    return false;
            }
        }

        public static Type GetTypeOf(TagClass className)
        {
            Type type;
            return definedTagGroupsDictionary.TryGetValue(className, out type) ? type : null;
        }

        internal static void ActiveMap(CacheStream mapstream)
        {
            mapStream = mapstream;
        }

        internal static bool ObjectChanged(TagIdent ident)
        {
            var newHash = mapStream.CalculateHash(ident);
            var currentHash = mapStream.GetTagHash(ident);
            if (currentHash == null) return false;
            var equals = currentHash == newHash;
            return !@equals;
        }

        internal static bool TryGettingResourceStream(ResourceSource resourceSource, out CacheStream resourceStream)
        {
            switch (resourceSource)
            {
                case ResourceSource.Shared:
                    resourceStream = resourceShared;
                    break;
                case ResourceSource.SinglePlayerShared:
                    resourceStream = resourceSinglePlayer;
                    break;
                case ResourceSource.MainMenu:
                    resourceStream = resourceMainMenu;
                    break;
                case ResourceSource.Local:
                    resourceStream = mapStream;
                    break;
                default:
                    resourceStream = null;
                    return false;
            }
            var hasResource = resourceStream != null;
            return hasResource;
        }

        internal static bool TryGettingResourceStream(int resourceAddress, out Stream resourceStream)
        {
            var pointer = (ResourcePointer) resourceAddress;
            switch (pointer.Source)
            {
                case ResourceSource.Shared:
                    resourceStream = resourceShared;
                    break;
                case ResourceSource.SinglePlayerShared:
                    resourceStream = resourceSinglePlayer;
                    break;
                case ResourceSource.MainMenu:
                    resourceStream = resourceMainMenu;
                    break;
                case ResourceSource.Local:
                    resourceStream = mapStream;
                    break;
                default:
                    resourceStream = null;
                    return false;
            }
            var success = resourceStream != null;
            return success;
        }
    }

    public static class Log
    {
        public delegate void LogMessageHandler(string message);

        public static LogMessageHandler OnLog;

        internal static void Error(string message)
        {
            LogMessage("Error", message);
        }

        internal static void Warn(string message)
        {
            LogMessage("Warning", message);
        }

        private static void LogMessage(string token, string message)
        {
            if (OnLog != null)
                OnLog(string.Format("{0}: {1}", token, message));
        }

        internal static void Info(string message)
        {
            LogMessage("Info", message);
        }
    }

    public static class StaticBenchmark
    {
        static List<long> _samples;
        private static readonly Stopwatch Timer = new Stopwatch();
        private static string _functionName;
        public static string Result { get; private set; }

        public static TimeSpan Performance { get; private set; }

        public static void SetCapacity(int size)
        {
            _samples = new List<long>(size);
        }

        public static void Begin(string functionName = "")
        {
            _samples = _samples ?? new List<long>();
            _functionName = functionName;
            Timer.Start();
        }

        public static void Sample()
        {
            Timer.Stop();
            if (_samples.Count >= _samples.Capacity)
                _samples.Clear();
            _samples.Add(Timer.ElapsedTicks);
            Timer.Reset();
        }

        public static void Clear()
        {
            var average = _samples.Sum() / _samples.Count;
            Performance = new TimeSpan(average);

            Result = string.Format("Average call time: {0}", Performance.Milliseconds < 1
                ? string.Format("{0}ticks", Performance.Ticks)
                : string.Format("{0}ms", Performance.TotalMilliseconds));
            _samples.Clear();
        }
    }

    public class TagGroupLookup : IEnumerable, IEnumerable<string>
    {
        private static readonly List<string> classes = new List<string>
        {
            #region Class Strings
            "$#!+",
            "*cen",
            "*eap",
            "*ehi",
            "*igh",
            "*ipd",
            "*qip",
            "*rea",
            "*sce",
            "/**/",
            "<fx>",
            "BooM",
            "DECP",
            "DECR",
            "MGS2",
            "PRTM",
            "adlg",
            "ai**",
            "ant!",
            "bipd",
            "bitm",
            "bloc",
            "bsdt",
            "char",
            "cin*",
            "clu*",
            "clwd",
            "coll",
            "coln",
            "colo",
            "cont",
            "crea",
            "ctrl",
            "dc*s",
            "dec*",
            "deca",
            "devi",
            "devo",
            "dgr*",
            "dobc",
            "effe",
            "egor",
            "eqip",
            "fog ",
            "foot",
            "fpch",
            "garb",
            "gldf",
            "goof",
            "grhi",
            "hlmt",
            "hmt ",
            "hsc*",
            "hud#",
            "hudg",
            "item",
            "itmc",
            "jmad",
            "jpt!",
            "lens",
            "lifi",
            "ligh",
            "lsnd",
            "ltmp",
            "mach",
            "matg",
            "mdlg",
            "metr",
            "mode",
            "mpdt",
            "mply",
            "mulg",
            "nhdt",
            "obje",
            "phmo",
            "phys",
            "pmov",
            "pphy",
            "proj",
            "prt3",
            "sbsp",
            "scen",
            "scnr",
            "sfx+",
            "shad",
            "sily",
            "skin",
            "sky ",
            "slit",
            "sncl",
            "snd!",
            "snde",
            "snmx",
            "spas",
            "spk!",
            "ssce",
            "sslt",
            "stem",
            "styl",
            "tdtl",
            "trak",
            "trg*",
            "udlg",
            "ugh!",
            "unhi",
            "unic",
            "unit",
            "vehc",
            "vehi",
            "vrtx",
            "weap",
            "weat",
            "wgit",
            "wgtz",
            "whip",
            "wigl",
            "wind",
            "wphi"

            #endregion
        };

        public string this[int index]
        {
            get { return classes[index]; }
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return classes.GetEnumerator();
        }

        #endregion

        #region IEnumerable<string> Members

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return classes.GetEnumerator();
        }

        #endregion
    }
}