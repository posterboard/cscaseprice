<?php

require_once './vendor/autoload.php';//direct file path //change later
function replaceFileName($originalName){   
    $newFileName = str_replace(" ","_",$originalName);
    echo join("",["./case_images/",$newFileName,".png"]);
}

function query($name){   
$connectionStr = "mongodb+srv://mainuser:UpxzsOcbvTZKsFHO@cluster0.pattjaw.mongodb.net/?retryWrites=true&w=majority";
$client = new MongoDB\Client(
    $connectionStr
);
$underscoreName = replaceFileName($name);


}
?>