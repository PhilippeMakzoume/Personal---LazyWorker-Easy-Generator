using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyGenerator_V2
{
    class ModelDataGenerator
    {
        public static void GenerateCreatureModel(string ModelData, string ModelName, string ModelID, string Texture1, string Texture2, string Texture3)
        {
            StringBuilder CreatureModelData = new StringBuilder();
            StringBuilder CreatureDisplayInfo = new StringBuilder();
            
            // Creature Model Data
            CreatureModelData.AppendLine(ModelData + ", 0,\"" + ModelName + "\",0,1.000000,3,4,18.000000,12.000000,1.000000,0,0,0,32,0.611100,2.031000,0.000000,-1.352985,-1.874912,-0.055337,1.621918,1.874008,3.237974,1.000000,1.000000,0.000000,0.000000,0.000000");
            // Creature Display Info
            CreatureDisplayInfo.AppendLine(ModelID + "," + ModelData + ",0,0,2.500000,255,\"" + Texture1 + "\",\"" + Texture2 + "\",\"" + Texture3 + "\",,0,0,0,0,0,0");

            if (!Directory.Exists("./Creature"))
                Directory.CreateDirectory("./Creature");

            File.AppendAllText ("./Creature/CreatureDisplayInfo.dbc.csv", CreatureDisplayInfo.ToString());
            File.AppendAllText("./Creature/CreatureModelData.dbc.csv", CreatureModelData.ToString());
        }
    }
}
