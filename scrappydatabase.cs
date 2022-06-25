using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using System.IO;
using MongoDB.Bson.Serialization.Attributes;

class Program {
   
    public static void Main(string[] args)
    {
        writeData();
        //UpxzsOcbvTZKsFHO
        //WhjY2BQmjW8SX5LL
      
        /*
         

        

        var result = collection.Find(new BsonDocument()).SortByDescending(m => m["runtime"]).Limit(10).ToList();

        foreach(var item in result)
        {
            Console.WriteLine(item);
        }
        */
    }
    public static  void writeData()
    {
        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://mainuser:UpxzsOcbvTZKsFHO@cluster0.pattjaw.mongodb.net/?retryWrites=true&w=majority");
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
