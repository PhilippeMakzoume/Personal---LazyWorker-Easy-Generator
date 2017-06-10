using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyGenerator_V2.Sources.Extension;

namespace LazyGenerator_V2.Sources.Gems
{
    class GemGenerator
    {
        public static void GenerateGem(int PropretiesID, string GemColor)
        {
            // Build
            StringBuilder GemProperties = new StringBuilder();


            if (!Directory.Exists("./Gems"))
                Directory.CreateDirectory("./Gems");

            GemProperties.AppendLine(PropretiesID + "," + PropretiesID + ",0,0," + GemColor.Before(" -"));

            File.AppendAllText(@".\Gems\GemProperties.dbc.csv",  GemProperties.ToString());
        }
    }
}
