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
            HttpClient client = new HttpClient();
            int currency = 1;//
            string urlExtension = "Operation%20Vanguard%20Weapon%20Case";


            Task<string> a = client.GetStringAsync("https://steamcommunity.com/market/priceoverview/?appid=730&currency=" + currency + "&market_hash_name=" + urlExtension);
            string outputDir = "C:/Users/zbria/Desktop/GloveOutput.txt";
            StreamWriter sw = new StreamWriter(outputDir);
            sw.Write(a.Result.ToString());
            sw.Close();



            /* for (int i= 0; i < 5; i++)
            {
                Console.Write(i);
                Thread.Sleep(2000);
            }
           */
        }
        private Task[] hello()
        {
            Task<string>[] jsonArray;

            return jsonArray;

        }
    }


  
}

//