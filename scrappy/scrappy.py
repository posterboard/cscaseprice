
import time
import json
import urllib.request
from datetime import datetime

from pymongo.mongo_client import MongoClient
from pymongo import InsertOne

from pymongo.server_api import ServerApi
from types import SimpleNamespace
class case:
    def __init__(self,name,dateTime,lowest_price,volume,median_price):
        self.name = name
        self.dateTime = dateTime
        self.lowest_price = lowest_price
        self.volume = volume
        self.median_price = median_price
class defaultCase:
    def __init__(self,success,lowest_price,volume,median_price):
        _id = ""
        self.success = success
        self.lowest_price = lowest_price
        self.volume = volume
        self.median_price = median_price
def jsonFromAPI(urlStr):
    url = urllib.request.urlopen(urlStr)
    page = url.read()
    return page

caseList = ["CSGO Weapon Case", "Operation Bravo Case", "CSGO weapon case 2", "Winter Offensive Case", " CSGO Weapon Case 3", "Operation Phoenix Case", "Huntsman Case", "Operation Breakout Case", " Operation Vanguard Case", "Chroma Case", "Chroma 2 Case ", "Falchion case", "Shadow Case", "Revolver Case", "Operation Wildfire Case", "Chroma 3 Case", "Gamma Case", "Gamma 2 Case", "Glove Case", "Spectrum Case", "Operation Hydra Case", "Spectrum 2 Case", "Clutch Case", "Horizon Case", "Danger Zone Case", "Prisma Case", "CS20 Case", "Operation Shattered Web Case", "Primsa 2 Case", "Fracture Case", "Operation Broken Fang Case", "Snakebite Case", "Operation Riptide Case", "Dreams and Nightmares Case" ,"Recoil Case"]
urlExtensionList = ["CS:GO%20Weapon%20Case", "Operation%20Bravo%20Case", "CS%3AGO%20Weapon%20Case%202", "Winter%20Offensive%20Weapon%20Case", "CS%3AGO%20Weapon%20Case%203", "Operation%20Phoenix%20Weapon%20Case", "Huntsman%20Weapon%20Case", "Operation%20Breakout%20Weapon%20Case", "Operation%20Vanguard%20Weapon%20Case", "Chroma%20Case", "Chroma%202%20Case", "Falchion%20Case", "Shadow%20Case", "Revolver%20Case", "Operation%20Wildfire%20Case", "Chroma%203%20Case", "Gamma%20Case", "Gamma%202%20Case", "Glove%20Case", "Spectrum%20Case", "Operation%20Hydra%20Case", "Spectrum%202%20Case", "Clutch%20Case", "Horizon%20Case", "Danger%20Zone%20Case", "Prisma%20Case", "CS20%20Case", "Shattered%20Web%20Case", "Prisma%202%20Case", "Fracture%20Case", "Operation%20Broken%20Fang%20Case", "Snakebite%20Case", "Operation%20Riptide%20Case", "Dreams%20%26%20Nightmares%20Case","Recoil%20Case" ]
objList = []
jsonList = ["empty"]*len(urlExtensionList)
for i in range(len(urlExtensionList)):
   
    try:
        jsonList[i]=jsonFromAPI("https://steamcommunity.com/market/priceoverview/?appid=730&currency=1&market_hash_name="+urlExtensionList[i])
        tempObj = json.loads(jsonList[i],object_hook=lambda defaultCase: SimpleNamespace(**defaultCase))
        caseObj = case(caseList[i],str(datetime.now()),tempObj.lowest_price,tempObj.volume,tempObj.median_price)
        jsonStr = json.dumps(caseObj.__dict__)
        notJsonStr = json.loads(jsonStr)
        objList.append(notJsonStr)

    except:
        print("fail: "+urlExtensionList[i])
        time.sleep(60)

connectionString = "mongodb+srv://mainuser:UpxzsOcbvTZKsFHO@cluster0.pattjaw.mongodb.net/?retryWrites=true&w=majority"
client = MongoClient(connectionString)
db = client['Case']
collection = db["CasePriceData"]
newCollection = db["CurrentPriceData"]
try:
    print(client.server_info())
except:
    print("could not connect")
collection.insert_many(objList)

newCollection.delete_many({})
newCollection.insert_many(objList)