using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LazyGenerator_V2.Sources.Item
{
    class ItemDisplayIconLibrary
    {
        static ConcurrentDictionary<string, string> _DictDisplayIcon = new ConcurrentDictionary<string, string> { };
        // New Library

        // Local Library
        public static void LoadMountInfoLibrary()
        {
            // Mount Name & Description from spell
            string XMLMountPath = "./Library/ItemDisplayIcon.xml";
            XElement doc = XElement.Load(XMLMountPath);
            IEnumerable<XElement> nodes = doc.Elements();
            string DisplayID, Icon_Name;

            foreach (var node in nodes)
            {
                DisplayID = node.Element("m_ID").Value;
                Icon_Name = node.Element("m_inventoryIcon").Value;
                _DictDisplayIcon.TryAdd(DisplayID, Icon_Name);
            }
        }
        // LocalLibrary Get
        public static string GetIconName(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictDisplayIcon.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }
    }
}
