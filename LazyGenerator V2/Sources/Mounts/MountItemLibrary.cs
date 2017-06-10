using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LazyGenerator_V2
{
    class MountItemLibrary
    {
        // Local Library
        static ConcurrentDictionary<string, string> _DictLocalItemID = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictLocalItemName = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictLocalItemIconName = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictLocalItemSpell = new ConcurrentDictionary<string, string> { };
        
        public static void LoadMountItemInfoLibrary()
        {
            // Mount Name & Description from spell
            string XMLMountPath = "./Library/ItemMount.xml";
            XElement doc = XElement.Load(XMLMountPath);
            IEnumerable<XElement> nodes = doc.Elements();
            string ItemEntry, Name, IconName, Spell;

            foreach (var node in nodes)
            {
                ItemEntry = node.Element("ItemID").Value;
                Name = node.Element("ItemName").Value;
                IconName = node.Element("ItemIconName").Value;
                Spell = node.Element("SpellID").Value;

                _DictLocalItemID.TryAdd(ItemEntry, ItemEntry);
                _DictLocalItemName.TryAdd(ItemEntry, Name);
                _DictLocalItemIconName.TryAdd(ItemEntry, IconName);
                _DictLocalItemSpell.TryAdd(ItemEntry, Spell);
            }
        }
        public static string GetLocalItemID(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictLocalItemID.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }
        public static string GetLocalItemName(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictLocalItemName.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }
        public static string GetLocalIconName(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictLocalItemIconName.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }
        public static string GetLocalSpell(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictLocalItemSpell.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }
    }
}
