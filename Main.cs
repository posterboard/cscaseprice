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
            Console.WriteLine("EHLLO WROLD");
            string itemUrl = "29/Operation-Vanguard-Weapon-Case";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument targetDoc = web.Load("https://csgostash.com/case/" + itemUrl);
            var HeaderNames = targetDoc.DocumentNode.SelectNodes("//span[@class='market_commodity_order__summary']");
            string output= "C:/Users/zbria/Desktop/GloveOutput.txt";




            StreamWriter sw = new StreamWriter(output);
            targetDoc.Save(sw);
            Console.WriteLine(sw);



            /* for (int i= 0; i < 5; i++)
            {
                Console.Write(i);
                Thread.Sleep(2000);
            }
           */
        }
        
    }
}

//