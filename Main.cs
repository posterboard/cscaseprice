using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
class Program
{
    public static void Main(string[] args)
    {
        int currency = 1;//



        //  Task<string> a = client.GetStringAsync("" + currency + "" + urlExtension);
        string outputDir ="./GloveOutput.txt";
        StreamWriter sw = new StreamWriter(outputDir,append: true);
        /*
        Csgo Weapn Case, Operation Bravo Case, CSGO weapon case 2, winter offensive casee, csgo weapon case3,
         operatiotn phoniex, huntsman, operation breakout, operation vanguard, chroma, chroma 2, falchion case, shadow case, revolver case,
        operation wildfire, chroma 3, gamma, gamma 2, glove, spectrum,  operation hydra, spectrum 2,clutch,  horizon case, danger zone, primsa, cs20,
        prisma 2, fracture, snakebite, dreams and nightmares
         
         */
        string[] caseNames = new string[] { "CSGO Weapon Case","Operation Bravo Case","CSGO weapon case 2","Winter Offensive Case"," CSGO Weapon Case 3","Operation Phoneix Case","Huntsman Case","Operation Breakout Case"," Operation Vanguard Case", "Chroma Case", "Chroma 2 Case "," Falchion case"," Shadow Case"," Revolver Case","Operation Wildfire Case","Chroma 3 Case","Gamma Case", "Gamma 2 Case","Glove Case","Spectrum Case","Operation Hydra Case", "Spectrum 2 Case","Clutch Case","Horizon Case","Danger Zone Case","Prisma Case","CS20 Case","Operation Shattered Web Case","Primsa 2 Case","Fracture Case","Operation Broken Fang Case","Snakebite Case","Operation Riptide Case","Dreams & Nightmares Case"};
        string[] urlExtensionList = new string[] { "CS:GO%20Weapon%20Case", "Operation%20Bravo%20Case","CS%3AGO%20Weapon%20Case%202", "Winter%20Offensive%20Weapon%20Case", "CS%3AGO%20Weapon%20Case%203" , "Operation%20Phoenix%20Weapon%20Case", "Huntsman%20Weapon%20Case", "Operation%20Breakout%20Weapon%20Case", "Operation%20Vanguard%20Weapon%20Case", "Chroma%20Case" , "Chroma%202%20Case", "Falchion%20Case" , "Shadow%20Case","Revolver%20Case", "Operation%20Wildfire%20Case", "Chroma%203%20Case", "Gamma%20Case", "Gamma%202%20Case", "Glove%20Case", "Spectrum%20Case", "Operation%20Hydra%20Case", "Spectrum%202%20Case", "Clutch%20Case", "Horizon%20Case", "Danger%20Zone%20Case", "Prisma%20Case" };
        string[] output = fetchApi(urlExtensionList, currency);
      ////////////////Deletelater
      sw.WriteLine();
      sw.WriteLine();
      sw.WriteLine();
      ////////////////
      sw.WriteLine(DateTime.Now);
        for (int i = 0; i < output.Length; i++)
        {
            /////dlete later
            sw.WriteLine(caseNames[i]);
            /////
            sw.WriteLine(output[i]);
            
        }
        sw.Close();




    }
    private static string[] fetchApi(string[] urlExtensionArray, int currency)
    {
        HttpClient client = new HttpClient();
        string urlExtension = "https://steamcommunity.com/market/priceoverview/?appid=730&currency=" + currency + "&market_hash_name=";
        string[] jsonString = new string[urlExtension.Length];
        Task<string> temp;
        Console.WriteLine(urlExtensionArray.Length);
      bool pass=false;
      bool reset = false;
      int startNum = 0;
      while(!pass){
        reset=true;
        pass=true;
      for (int i = startNum; i < urlExtensionArray.Length; i++)
        {
            Console.WriteLine(i);
          try{
            temp = client.GetStringAsync(urlExtension + urlExtensionArray[i]);
            //Thread.Sleep(1000);
            jsonString[i] = temp.Result;
          }catch(Exception e){
            if(reset){
              startNum=i;
              reset=false;
              
            }
            pass=false;
            Console.WriteLine("Failed");
          }
        }
        //my only solution to Error 429
        if(!pass){
        Console.WriteLine("sleeping");
        Thread.Sleep(30000);
        Console.WriteLine("not sleepign");
        }
        
      }
 var tempList = new List<string>();
foreach (var s in jsonString)
{
    if (!string.IsNullOrEmpty(s))
        tempList.Add(s);
}
jsonString = tempList.ToArray();
return jsonString;
    }
}
