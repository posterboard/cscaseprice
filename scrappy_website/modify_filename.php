<?php

function replaceFileName($originalName){   
    $newFileName = str_replace(" ","_",$originalName);
    echo join("",["./case_images/",$newFileName,".png"]);
}

?>