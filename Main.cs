using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Amazon;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
class Program
{
    private static AmazonDynamoDBClient aClient = new AmazonDynamoDBClient(RegionEndpoint.USEast1);

    public static void Main(string[] args)
    {
        writeData();
        String direct =  Environment.GetLogicalDrives()[0]+"/Users/"+ Environment.UserName+"/Desktop/CaseOutput.txt";
  
        updateCaseValues(1, direct);
        
    }
    private static void updateCaseValues(int c, string directory)
    {
        int currency = c;//



        string outputDir = directory;
        StreamWriter sw = new StreamWriter(outputDir, append: true);
        string[] caseNames = new string[] { "CSGO Weapon Case", "Operation Bravo Case", "CSGO weapon case 2", "Winter Offensive Case", " CSGO Weapon Case 3", "Operation Phoneix Case", "Huntsman Case", "Operation Breakout Case", " Operation Vanguard Case", "Chroma Case", "Chroma 2 Case ", " Falchion case", " Shadow Case", " Revolver Case", "Operation Wildfire Case", "Chroma 3 Case", "Gamma Case", "Gamma 2 Case", "Glove Case", "Spectrum Case", "Operation Hydra Case", "Spectrum 2 Case", "Clutch Case", "Horizon Case", "Danger Zone Case", "Prisma Case", "CS20 Case", "Operation Shattered Web Case", "Primsa 2 Case", "Fracture Case", "Operation Broken Fang Case", "Snakebite Case", "Operation Riptide Case", "Dreams & Nightmares Case" };
        string[] urlExtensionList = new string[] { "CS:GO%20Weapon%20Case", "Operation%20Bravo%20Case", "CS%3AGO%20Weapon%20Case%202", "Winter%20Offensive%20Weapon%20Case", "CS%3AGO%20Weapon%20Case%203", "Operation%20Phoenix%20Weapon%20Case", "Huntsman%20Weapon%20Case", "Operation%20Breakout%20Weapon%20Case", "Operation%20Vanguard%20Weapon%20Case", "Chroma%20Case", "Chroma%202%20Case", "Falchion%20Case", "Shadow%20Case", "Revolver%20Case", "Operation%20Wildfire%20Case", "Chroma%203%20Case", "Gamma%20Case", "Gamma%202%20Case", "Glove%20Case", "Spectrum%20Case", "Operation%20Hydra%20Case", "Spectrum%202%20Case", "Clutch%20Case", "Horizon%20Case", "Danger%20Zone%20Case", "Prisma%20Case" };
        string[] output = new string[urlExtensionList.Length]; //fetchApi(urlExtensionList, currency,client);

        sw.WriteLine(DateTime.Now);
        HttpClient client = new HttpClient();
        string result;
        CaseData currentCase;
        var options = new JsonSerializerOptions{WriteIndented = true};
        for (int i = 0; i < urlExtensionList.Length; i++)
        {
            result = fetchApi(urlExtensionList[i], 1, client);


            //insert name into json
            currentCase = deSerializeJson(result);
            currentCase.name=caseNames[i];

            sw.WriteLine(JsonSerializer.Serialize(currentCase));
        }
        sw.Close();

        Console.WriteLine("Not here");
        
    }
    private static string fetchApi(string urlExtension, int currency, HttpClient c)
    {
        HttpClient client = c;
        string url = "https://steamcommunity.com/market/priceoverview/?appid=730&currency=" + currency + "&market_hash_name=";
        string[] jsonString = new string[urlExtension.Length];
        Task<string> temp;
        bool pass = false;
        bool reset = false;
        string output = "";
        while (!pass)
        {
            reset = true;
            pass = true;
            try
            {
                temp = client.GetStringAsync(url + urlExtension);
                output = temp.Result;
                Console.WriteLine("Sucess " + urlExtension);
            }
            catch (Exception e)
            {
                if (reset)
                {

                    reset = false;

                }
                pass = false;
                Console.WriteLine("Failed" + urlExtension + " retrying");
            }

            //my only solution to Error 429
            if (!pass)
            {
                //20 requests per minute apparently
                Thread.Sleep(60000);
                 
            }

        }
        var tempList = new List<string>();
        foreach (var s in jsonString)
        {
            if (!string.IsNullOrEmpty(s))
                tempList.Add(s);
        }
        jsonString = tempList.ToArray();
        return output;
    }
    private static string[] deSerializeJsonFromFile(String fileLoc)
    {
        StreamReader r = new StreamReader(fileLoc);
        string json = r.ReadToEnd();
        Console.WriteLine(json);
        string[] h = new string[2];
        return h;
    }

    private static void writeData()
    {
        
       
        try
        {
            Table t = Table.LoadTable(aClient,"Cases");

        }catch(Exception e)
        {
            Console.WriteLine(e.ToString());
        }
       
    }
    private static CaseData deSerializeJson(String json)
    {
        //%20 =spacae
        //%3A = colon
       
        
        CaseData cD =  JsonSerializer.Deserialize<CaseData>(json);


        return cD;
    }
    public class CaseData
    {
        public string name { get; set; }
        public string lowest_price { get; set; }
        public string volume { get; set; }
        public string median_price { get; set; }
        
    }
}
