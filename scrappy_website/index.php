<!DOCTYPE html>
<html>

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width">
  <title>CS:GO Case Prices</title>
  <link rel="icon" type="image/x-icon" href="./favicon.ico?">
  <link href="./style.css" rel="stylesheet" type="text/css" />
  

  
</head>

<body >
  <navigation>
    <div class="header">
    <ul>
        <li><a href="index.php">CSGO Case Prices</a></li>
        <li><a href="./about.html">About</a></li>
       
      </ul>
    </div>    
  </navigation> 
  <h1 id="lol" class="title">Case List:</h1>

  <div id="list-of-cases" onload="setPriceChange()">

      <?php 
      require "scrappy_website_db.php";
      require "modify_filename.php";
      require "./cases/query.php";
      
      foreach ($case as $i) { 
        list($pPrice,$cPrice)=queryCaseData($i["name"],1,2);
      ?>
      <a href=<?php replaceFileName($i["name"])?> > 
     
        <div class="case-wrap" data-id="<?=$i["_id"]?>" id="<?=$i["url"]?>">
          <div class="case-name"><?=$i["name"]?></div>
          <div class="case-price">Price: <?=$i["median_price"]?></div>
          <price past_price= <?php echo $pPrice ?> current_price=<?php echo $cPrice ?>> </price>
          <img src=<?php replaceFileName($i["name"])?>>
        </div>
      </a>
      <?php }
      
    ?>
    </div>
    <script src="./script.js"></script> 
    
    <footer>

    
    <p>Case Prices Last Updated: <?php require "scrappy_website_db.php"; echo $date;?></p>  
    <a href = "./about.html"><p>About</p></a>
    <a href ="https://github.com/zbrianhuang/cscaseprice"><p>Github</p></a>
  </footer>
</body>

</html>