<?php

require_once './vendor/autoload.php';//change later

function queryCaseData($name, $yeslimit, $limit){   
    $connectionStr = "mongodb+srv://mainuser:UpxzsOcbvTZKsFHO@cluster0.pattjaw.mongodb.net/?retryWrites=true&w=majority";
    $client = new MongoDB\Client($connectionStr);
    $db = $client->Case;   
    $collection = $db->CasePriceData; 
    if(!$yeslimit){
        $cursor = $collection->find(['name'=>$name]);
    }else{
        //$cursor = $collection->find(['name'=>$name],['limit'=>$limit]);
        $counter= $collection->count(['name'=>$name]);
        $iterate = $counter-$limit;
        $cursor = $collection->find(['name'=>$name],['skip'=>$iterate]);
        
    }

    /*
    foreach ($cursor as $i){
        echo $i['lowest_price'];
        echo $i['dateTime'],"\n";
    }
    */
    $arr = array(); 
    foreach ($cursor as $i){
        array_push($arr,$i['lowest_price']);
        
    }
    return $arr;
    

}

function removeDollarSign($input){
    return substr($input,1);
}
?>