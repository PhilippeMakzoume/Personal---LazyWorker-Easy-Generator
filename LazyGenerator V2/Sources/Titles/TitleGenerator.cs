using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyGenerator_V2.Sources.Titles
{
    class TitleGenerator
    {
        public static void GenerateTitle(string TitleNameMale, string TitleNameFemale, int ID, string lang)
        {
            string result = "";

            result += ID;
            result += ",";
            result += "REPLACETHIS1";
            result += "\"" + TitleNameMale + "\"";
            result += "REPLACETHIS2";
            result += "\"" + TitleNameFemale + "\"";
            result += "REPLACETHIS3";
            result += ID;
            result += "\n";

            if (!Directory.Exists("./Titles/" + lang))
                Directory.CreateDirectory("./Titles/" + lang);

            switch (lang)
            {
                case "FR":
                    File.AppendAllText("./Titles/"+ lang + "/CharTitles.dbc.csv", result.Replace("REPLACETHIS1", "0,0,0,").Replace("REPLACETHIS2", ",0,0,0,0,0,0,0,0,0,0,0,0,0,16712190,0,0,").Replace("REPLACETHIS3", ",0,0,0,0,0,0,0,0,0,0,0,0,0,16712190,"));
                    break;
                case "US":
                    File.AppendAllText("./Titles/" + lang + "/CharTitles.dbc.csv", result.Replace("REPLACETHIS1", "0,").Replace("REPLACETHIS2", ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16712190,").Replace("REPLACETHIS3", ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16712190,"));         
                    break;
                case "EN":
                    File.AppendAllText("./Titles/" + lang + "/CharTitles.dbc.csv", result.Replace("REPLACETHIS1", "0,").Replace("REPLACETHIS2", ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16712190,").Replace("REPLACETHIS3", ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16712190,"));
                    break;
                case "ES":
                    File.AppendAllText("./Titles/" + lang + "/CharTitles.dbc.csv", result.Replace("REPLACETHIS1", "0,0,0,0,0,0,0,").Replace("REPLACETHIS2", ",0,0,0,0,0,0,0,0,0,16712190,0,0,0,0,0,0,").Replace("REPLACETHIS3", ",0,0,0,0,0,0,0,0,0,16712190,"));
                    break;
                case "MX":
                    File.AppendAllText("./Titles/" + lang + "/CharTitles.dbc.csv", result.Replace("REPLACETHIS1", "0,0,0,0,0,0,0,0,").Replace("REPLACETHIS2", ",0,0,0,0,0,0,0,0,16712190,0,0,0,0,0,0,0,").Replace("REPLACETHIS3", ",0,0,0,0,0,0,0,0,16712190,"));
                    break;
                case "RU":
                    File.AppendAllText("./Titles/" + lang + "/CharTitles.dbc.csv", result.Replace("REPLACETHIS1", "0,0,0,0,0,0,0,0,0,").Replace("REPLACETHIS2", ",0,0,0,0,0,0,0,16712190,0,0,0,0,0,0,0,0,").Replace("REPLACETHIS3", ",0,0,0,0,0,0,0,16712190,"));
                    break;
                case "DE":
                    File.AppendAllText("./Titles/" + lang + "/CharTitles.dbc.csv", result.Replace("REPLACETHIS1", "0,0,0,0,").Replace("REPLACETHIS2", ",0,0,0,0,0,0,0,0,0,0,0,0,16712190,0,0,0,").Replace("REPLACETHIS3", ",0,0,0,0,0,0,0,0,0,0,0,0,16712190,"));
                    break;
            }
        }
    }
}
