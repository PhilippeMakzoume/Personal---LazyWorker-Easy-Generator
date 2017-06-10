using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LazyGenerator_V2
{
    class SpellLibrary
    {
        // Dictionaries
        static ConcurrentDictionary<string, string> _DicSpellIcon = new ConcurrentDictionary<string, string> { };

        // General Things
        public static void LoadSpellIconLibrary()
        {
            // SpellIcon
            string XMLFilePath = "./Library/SpellIcon.xml";
            XElement doc = XElement.Load(XMLFilePath);
            IEnumerable<XElement> nodes = doc.Elements();
            string IconID, IconName;
            IconName = "";
            IconID = "";

            foreach (var node in nodes)
            {
                IconID = node.Element("ID").Value;
                IconName = node.Element("SpellIcon").Value;

                _DicSpellIcon.TryAdd(IconName.ToLower(), IconID);
            }
        }

        public static string GetKeySpellIcon(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DicSpellIcon.TryGetValue(Key, out result))
                return result;
            else
                return "0";
        }
    }
}
