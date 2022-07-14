
<?php
$client = new MongoDB("mongodb+srv://reader:02IFsEcNvuvTbhLJ@cluster0.pattjaw.mongodb.net/?retryWrites=true&w=majority");
$db = $client->Case;   
$collection = $db->CasePriceData; 
$name1 = $collection.getCollectionName();
var_dump($name1);
?>
