using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LazyGenerator_V2.Sources.Pets
{
    class PetItemLibrary
    {
        // Local Library
        static ConcurrentDictionary<string, string> _DictLocalSpellID = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictLocalItemID = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictLocalItemName = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictLocalItemIconName = new ConcurrentDictionary<string, string> { };

        public static void LoadPetItemInfoLibrary()
        {
            // Mount Name & Description from spell
            string XMLMountPath = "./Library/PetItem.xml";
            XElement doc = XElement.Load(XMLMountPath);
            IEnumerable<XElement> nodes = doc.Elements();
            string SpellID, ItemID, ItemName, IconName;

            foreach (var node in nodes)
            {
                ItemID = node.Element("ItemID").Value;
                SpellID = node.Element("SpellID").Value;
                ItemName = node.Element("Name").Value;
                IconName = node.Element("ItemIcon").Value;

                _DictLocalItemID.TryAdd(ItemID, ItemID); 
                _DictLocalSpellID.TryAdd(ItemID, SpellID);
                _DictLocalItemName.TryAdd(ItemID, ItemName);
                _DictLocalItemIconName.TryAdd(ItemID, IconName);
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
        public static string GetLocalSpellID(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictLocalSpellID.TryGetValue(Key, out result))
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
    }
}
