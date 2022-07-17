
<?php
require_once 'C:/Users/zbria/vendor/autoload.php';
// mongodb+srv://reader:02IFsEcNvuvTbhLJ@cluster0.pattjaw.mongodb.net/?retryWrites=true&w=majority
//mongodb+srv://mainuser:UpxzsOcbvTZKsFHO@cluster0.pattjaw.mongodb.net/?retryWrites=true&w=majority
$connectionStr = "mongodb+srv://reader:02IFsEcNvuvTbhLJ@cluster0.pattjaw.mongodb.net/?retryWrites=true&w=majority";
$client = new MongoDB\Client(
    $connectionStr
);
$db = $client->Case;   
$collection = $db->CurrentPriceData; 
$case = $collection->find();

?>
