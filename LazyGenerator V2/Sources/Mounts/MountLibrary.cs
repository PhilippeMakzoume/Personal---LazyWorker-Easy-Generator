using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LazyGenerator_V2
{
    class MountLibrary
    {
        // Dictionary
        // Local Library
        static ConcurrentDictionary<string, string> _DictMountName = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictMountDescription = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictCreatureEntry = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictDisplayID = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictIconName = new ConcurrentDictionary<string, string> { };
        // New Library

        // Local Library
        public static void LoadMountInfoLibrary()
        {
            // Mount Name & Description from spell
            string XMLMountPath = "./Library/Mounts.xml";
            XElement doc = XElement.Load(XMLMountPath);
            IEnumerable<XElement> nodes = doc.Elements();
            string MountSpellID, Name, Description, CreatureEntry, DisplayID, IconName;

            foreach (var node in nodes)
            {
                MountSpellID = node.Element("SpellID").Value;
                Name = node.Element("SpellName").Value;
                Description = node.Element("SpellDescription").Value;
                CreatureEntry = node.Element("CreatureEntry").Value;
                DisplayID = node.Element("DisplayID").Value;
                IconName = node.Element("IconName").Value;

                _DictMountName.TryAdd(MountSpellID, Name);
                _DictMountDescription.TryAdd(MountSpellID, Description);
                _DictCreatureEntry.TryAdd(MountSpellID, CreatureEntry);
                _DictDisplayID.TryAdd(MountSpellID, DisplayID);
                _DictIconName.TryAdd(MountSpellID, IconName);
            }
        }
        // LocalLibrary Get
        public static string GetKeyCreatureEntry(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictCreatureEntry.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }
        public static string GetKeyDisplayID(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictDisplayID.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }
        public static string GetKeyIconName(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictIconName.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }
        public static string GetKeyMountName(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictMountName.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }
        public static string GetKeyMountDescription(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictMountDescription.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }

        public static void AddToMountLibrary(string SpellID, string CreatureEntry, string SpellName, string SpellDescription, string DisplayID, string IconName)
        {
            // TODO update node if existing
            XDocument doc1 = XDocument.Load("./Library/Mounts.xml");
            XElement MountsXML =
                new XElement("row",
                new XElement("SpellID", SpellID),
                new XElement("CreatureEntry", CreatureEntry),
                new XElement("SpellName", SpellName),
                new XElement("SpellDescription", SpellDescription),
                new XElement("DisplayID", DisplayID),
                new XElement("IconName", IconName));
            doc1.Root.Add(MountsXML);
            doc1.Save("./Library/Mounts.xml");
        }
    }
}
