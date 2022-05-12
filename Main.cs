using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

class Program {
  public static void Main (string[] args) {
                int currency = 1;//



          //  Task<string> a = client.GetStringAsync("" + currency + "" + urlExtension);
            string outputDir = "./GloveOutput.txt";
            StreamWriter sw = new StreamWriter(outputDir);
            string[] urlExtensionList = new string[] { "Operation%20Vanguard%20Weapon%20Case", "Operation&20Riptide%20Weapon%20Case","Clutch%20Case", "Glove%20Case","Danger%20Zone%20Case","Clutch%20Case" };
            string[] output = fetchApi(urlExtensionList, 3);

            for (int i = 0; i < output.Length; i++)
            {
             
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
