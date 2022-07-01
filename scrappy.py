import time
import json
import urllib.request
from lxml import html
from pymongo.mongo_client import MongoClient
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
    def __init__(self,success,dateTime,lowest_price,volume,median_price):
        self.success = success
        self.dateTime = dateTime
        self.lowest_price = lowest_price
        self.volume = volume
        self.median_price = median_price
def jsonFromAPI(urlStr):
    url = urllib.request.urlopen(urlStr)
    page = url.read()
    print(page)
    return page

urlExtensionList = ["CS:GO%20Weapon%20Case", "Operation%20Bravo%20Case", "CS%3AGO%20Weapon%20Case%202", "Winter%20Offensive%20Weapon%20Case", "CS%3AGO%20Weapon%20Case%203", "Operation%20Phoenix%20Weapon%20Case", "Huntsman%20Weapon%20Case", "Operation%20Breakout%20Weapon%20Case", "Operation%20Vanguard%20Weapon%20Case", "Chroma%20Case", "Chroma%202%20Case", "Falchion%20Case", "Shadow%20Case", "Revolver%20Case", "Operation%20Wildfire%20Case", "Chroma%203%20Case", "Gamma%20Case", "Gamma%202%20Case", "Glove%20Case", "Spectrum%20Case", "Operation%20Hydra%20Case", "Spectrum%202%20Case", "Clutch%20Case", "Horizon%20Case", "Danger%20Zone%20Case", "Prisma%20Case", "CS20%20Case", "Shattered%20Web%20Case", "Prisma%202%20Case", "Fracture%20Case", "Operation%20Broken%20Fang%20Case", "Snakebite%20Case", "Operation%20Riptide%20Case", "Dreams%20%26%20Nightmares%20Case" ]
jsonList = ["empty"]*len(urlExtensionList)
for i in range(len(urlExtensionList)):
    try:
        jsonList[i]=jsonFromAPI("https://steamcommunity.com/market/priceoverview/?appid=730&currency=1&market_hash_name="+urlExtensionList[i])
    except:
        print("fail: "+urlExtensionList[i])
        time.sleep(60)
        
a = json.loads(jsonFromAPI("https://steamcommunity.com/market/priceoverview/?appid=730&currency=1&market_hash_name="+urlExtensionList[1]),object_hook=lambda case: SimpleNamespace(**case))
print(a.name)
