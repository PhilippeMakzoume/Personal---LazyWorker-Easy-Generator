using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LazyGenerator_V2.Sources.Pets
{
    class PetLibrary
    {
        // Dictionary
        // Local Library
        static ConcurrentDictionary<string, string> _DictPetSpellID = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictPetSpellName = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictPetCreatureID = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictPetCreatureDisplayID = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictPetSpellIconName = new ConcurrentDictionary<string, string> { };
        static ConcurrentDictionary<string, string> _DictPetSpellIconID = new ConcurrentDictionary<string, string> { };
        // XML Modifier

        public static void LoadPetInfoLibrary()
        {
            // Mount Name & Description from spell
            string XMLMountPath = "./Library/Pets.xml";
            XElement doc = XElement.Load(XMLMountPath);
            IEnumerable<XElement> nodes = doc.Elements();
            string PetSpellID, PetSpellName, PetCreatureID, PetCreatureDisplayID, PetSpellIconName, PetSpellIconID;

            foreach (var node in nodes)
            {
                PetSpellID = node.Element("SpellID").Value;
                PetSpellName = node.Element("Name").Value;
                PetCreatureID = node.Element("CreatureID").Value;
                PetCreatureDisplayID = node.Element("DisplayID").Value;
                PetSpellIconName = node.Element("Icon").Value;
                PetSpellIconID = node.Element("IconID").Value;

                _DictPetSpellID.TryAdd(PetSpellID, PetSpellID);
                _DictPetSpellName.TryAdd(PetSpellID, PetSpellName);
                _DictPetCreatureID.TryAdd(PetSpellID, PetCreatureID);
                _DictPetCreatureDisplayID.TryAdd(PetSpellID, PetCreatureDisplayID);
                _DictPetSpellIconName.TryAdd(PetSpellID, PetSpellIconName);
                _DictPetSpellIconID.TryAdd(PetSpellID, PetSpellIconID);
            }
        }

        // LocalLibrary Get
        public static string GetKeySpellIconName(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictPetSpellIconName.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }

        public static string GetKeyPetSpellIconID(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictPetSpellIconID.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }

        public static string GetKeyPetCreatureID(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictPetCreatureID.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }

        public static string GetKeyPetCreatureDisplayID(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictPetCreatureDisplayID.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }

        public static string GetKeyPetSpellID(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictPetSpellID.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }

        public static string GetKeyPetSpellName(string Key)
        {
            // Try to get the result in the static Dictionary
            string result;
            if (_DictPetSpellName.TryGetValue(Key, out result))
                return result;
            else
                return "";
        }

        public static void AddToPetXmlLibrary(string SpellID, string CreatureID, string DisplayID, string Name, string Icon, string IconID)
        {
            XDocument doc = XDocument.Load("./Library/Pets.xml");
            XElement PetsXML = 
                new XElement("row",
                new XElement("SpellID", SpellID),
                new XElement("CreatureID", CreatureID),
                new XElement("DisplayID", DisplayID),
                new XElement("Name", Name),
                new XElement("Icon", Icon),
                new XElement("IconID", IconID));
            doc.Root.Add(PetsXML);
            doc.Save("./Library/Pets.xml");
        }
    }
}
