using LazyGenerator_V2.Sources.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyGenerator_V2.Sources.Gems
{
    class GemItemEnchantementGenerator
    {
        public static void GenerateGemItemEnchantement(int PropretiesID, // GemPropreties
            string StatType1, string StatCoef1,  // SpellItemEnchantement
            string StatType2, string StatCoef2,  // SpellItemEnchantement
            string ItemID, bool DoubleStats,
            string lang)
        {
            StringBuilder SpellItemEnchant = new StringBuilder();

            if (!Directory.Exists("./Gems/"+ lang))
                Directory.CreateDirectory("./Gems/"+ lang);

            if (!DoubleStats)
            {
                if (lang == "EN")
                    SpellItemEnchant.AppendLine(PropretiesID + ",0,5,0,0," + StatCoef1 + ",0,0," + StatCoef1 + ",0,0," + StatType1.Before(" -") + ",0,0,DoubleQuote+ " + StatCoef1 + StatType1.After("-") + "DoubleQuote,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16712190,0,0," + ItemID + ",0,0,0,0");
                else if (lang == "FR")
                    SpellItemEnchant.AppendLine(PropretiesID + ",0,5,0,0," + StatCoef1 + ",0,0," + StatCoef1 + ",0,0," + StatType1.Before(" - ") + ",0,0,0,0,DoubleQuote+" + StatCoef1 + StatType1.After("-") + "DoubleQuote,0,0,0,0,0,0,0,0,0,0,0,0,0,16712190,0,0," + ItemID + ",0,0,0,0");
                else if (lang == "US")
                    SpellItemEnchant.AppendLine("");
            }
            else
            {
                if (lang == "EN")
                    SpellItemEnchant.AppendLine(PropretiesID + ",0,5,5,0," + StatCoef1 + "," + StatCoef2 + ",0," + StatCoef1 + "," + StatCoef2 + ",0," + StatType1.Before(" -") + "," + StatType2.Before(" -") + ",0,DoubleQuote+ " + StatCoef1 + StatType1.After("-") + " and +" + StatCoef2 + StatType2.After("-") + "DoubleQuote,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16712190,0,0," + ItemID + ",0,0,0,0");
                else if (lang == "FR")
                    SpellItemEnchant.AppendLine(PropretiesID + ",0,5,5,0," + StatCoef1 + "," + StatCoef2 + ",0," + StatCoef1 + "," + StatCoef2 + ",0," + StatType1.Before(" -") + "," + StatType2.Before(" -") + ",0,0,0,DoubleQuote+ " + StatCoef1 + StatType1.After("-") + " et +" + StatCoef2 + StatType2.After("-") + "DoubleQuote,0,0,0,0,0,0,0,0,0,0,0,0,0,16712190,0,0," + ItemID + ",0,0,0,0");
                else if (lang == "US")
                    SpellItemEnchant.AppendLine("");
                
            }

            File.AppendAllText("./Gems/" + lang + "/SpellItemEnchantment.dbc.csv", SpellItemEnchant.ToString().Replace("DoubleQuote", "\""));
        }
    }
}
