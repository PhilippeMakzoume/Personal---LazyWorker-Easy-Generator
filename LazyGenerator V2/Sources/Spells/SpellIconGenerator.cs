using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyGenerator_V2
{
    class SpellIconGenerator
    {
        public static void GenerateSpellIcon(string IconID, string IconName)
        {
            StringBuilder SpellIcon = new StringBuilder();

            string Path = "\"Interface\\Icons\\";

            SpellIcon.AppendLine(IconID + "," + Path + IconName + "\"");

            if (!Directory.Exists("/Icon"))
                Directory.CreateDirectory("./Icon");

            File.AppendAllText("./Icon/SpellIcon.dbc.csv", SpellIcon.ToString());
        }
    }
}
