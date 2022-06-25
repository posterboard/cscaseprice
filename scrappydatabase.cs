using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using System.IO;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Configuration;
class Program {
   
    public static void Main(string[] args)
    {
        writeData();
    }
    public static  void writeData()
    {
        
        string connectionURI = ConfigurationManager.ConnectionStrings["MongoDBString"].ConnectionString+  "/?retryWrites=true&w=majority";
        Console.WriteLine(connectionURI);
        var settings = MongoClientSettings.FromConnectionString(connectionURI);
        var client = new MongoClient(settings);
        var database = client.GetDatabase("Case");
        string txtDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/scrappy";
        string[] caseLine = File.ReadAllLines(txtDir + "/tmpCaseOutput.txt");
        CaseData[] caseList = new CaseData[caseLine.Length];
        var listWrites = new List<WriteModel<CaseData>>();
        CaseData temp;
        foreach (string line in caseLine)
        {
            temp = deSerializeJson(line);
            listWrites.Add(new InsertOneModel<CaseData>(temp));
            // Console.WriteLine(line);
        }
        var collection = database.GetCollection<CaseData>("CasePriceData");
        var writeResults = collection.BulkWrite(listWrites);
        Console.WriteLine($"OK?: {writeResults.IsAcknowledged} - Inserted Count: {writeResults.InsertedCount}");
    }
    public class CaseData
    {
        [BsonId] public ObjectId _id { get; set; }
        public string name { get; set; }
        public string dateTime { get; set; }
        public string lowest_price { get; set; }
        public string volume { get; set; }
        public string median_price { get; set; }

    }
    private static CaseData deSerializeJson(String json)
    {
        //%20 =spacae
        //%3A = colon


        CaseData cD = JsonSerializer.Deserialize<CaseData>(json);


        return cD;
    }
}
