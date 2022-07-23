<!DOCTYPE html>
<html>

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width">
  <title>CS:GO Case Prices</title>
  <link rel="icon" type="image/x-icon" href="./favicon.ico?">
  <link href="./style.css" rel="stylesheet" type="text/css" />
  
  
</head>

<body>
 
  <header>csgo case price viewer.</header>
  <navigation>
    <div class="header">
      <p>Case List</p>
      <input type="text" id="searchBar" placeholder="Search..">
    </div>    
  </navigation> 
  <h1 id="lol" class="title">Case List:</h1>
  <script src="./script.js"></script> 
  <div id="list-of-cases">

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


    
    <footer>

    
    <p>Case Prices Last Updated: <?php require "scrappy_website_db.php"; echo $date;?></p>  
    <a href = "./about.html"><p>About</p></a>
    <a href ="https://github.com/zbrianhuang/cscaseprice"><p>Github</p></a>
  </footer>
</body>

</html>
