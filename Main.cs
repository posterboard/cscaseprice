using CsvHelper;
using HtmlAgilityPack;
using Jurassic;
//See https://aka.ms/new-console-template for more information

namespace Main
{

    class Program
    {
        
        static void Main(string[] args)
        {

            int currency = 1;//



          //  Task<string> a = client.GetStringAsync("" + currency + "" + urlExtension);
            string outputDir = "C:/Users/zbria/Desktop/GloveOutput.txt";
            StreamWriter sw = new StreamWriter(outputDir);
            string[] urlExtensionList = new string[] { "Operation%20Vanguard%20Weapon%20Case", "Clutch%20Case", "Glove%20Case" };
            string[] output = fetchApi(urlExtensionList, 3);

            for (int i = 0; i < output.Length; i++)
            {
                //Console.WriteLine(i);
                Console.WriteLine(output[i]+"\n");
                sw.Write(output[i]);
            }
            sw.Close();



        }
        private static string[] fetchApi(string[] urlExtensionArray, int currency)
        {
            HttpClient client = new HttpClient();
            string urlExtension = "https://steamcommunity.com/market/priceoverview/?appid=730&currency=" + currency + "&market_hash_name=";
            string[] jsonString = new string[urlExtension.Length];
            Task<string> temp;
            for (int i = 0; i < urlExtensionArray.Length; i++)
            {
                Console.WriteLine(i);
                temp = client.GetStringAsync(urlExtension+urlExtensionArray[i]);
                jsonString[i] = temp.Result;
            }

            return jsonString;

        }
    }


  
}

//