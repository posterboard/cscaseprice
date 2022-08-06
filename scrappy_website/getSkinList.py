import time
import urllib.request
import requests

url = 'https://csgostash.com/containers/skin-cases'
headers = {'User-Agent': 'CoolBot/0.0 (https://example.org/coolbot/; coolbot@example.org)'}

response = requests.get(url, headers=headers)
print(response.text)
def getHTML(urlStr):
    url = urllib.request.urlopen(urlStr)
    page = url.read()
    return str(page)

urlExtensionList = ["CS%3AGO%20Weapon%20Case", "Operation%20Bravo%20Case", "CS%3AGO%20Weapon%20Case%202", "Winter%20Offensive%20Weapon%20Case", "CS%3AGO%20Weapon%20Case%203", "Operation%20Phoenix%20Weapon%20Case", "Huntsman%20Weapon%20Case", "Operation%20Breakout%20Weapon%20Case", "Operation%20Vanguard%20Weapon%20Case", "Chroma%20Case", "Chroma%202%20Case", "Falchion%20Case", "Shadow%20Case", "Revolver%20Case", "Operation%20Wildfire%20Case", "Chroma%203%20Case", "Gamma%20Case", "Gamma%202%20Case", "Glove%20Case", "Spectrum%20Case", "Operation%20Hydra%20Case", "Spectrum%202%20Case", "Clutch%20Case", "Horizon%20Case", "Danger%20Zone%20Case", "Prisma%20Case", "CS20%20Case", "Shattered%20Web%20Case", "Prisma%202%20Case", "Fracture%20Case", "Operation%20Broken%20Fang%20Case", "Snakebite%20Case", "Operation%20Riptide%20Case", "Dreams%20%26%20Nightmares%20Case","Recoil%20Case" ]
skinList=[]
#print(getHTML("https://steamcommunity.com/market/listings/730/"+urlExtensionList[1]))
#for i in range(len(urlExtensionList)):
    
        
    
    
        #print("failed: ")
        #time.sleep(60)
