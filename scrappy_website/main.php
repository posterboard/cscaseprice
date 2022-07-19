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
  <script src="./script.js"></script>
  <header>csgo case price viewer.</header>
  <navigation>
    <ul>
      <li>Case List</li>
    </ul>
  </navigation> 
  <h1 class="title">Case List:</h1>
  <p>Last Updated: <?php require "scrappy_website_db.php"; echo $date;?></p>
  <div id="list-of-cases">
      <?php 
      require "scrappy_website_db.php";
      require "modify_filename.php";
      foreach ($case as $i) { 
        ?>
      <a href=<?php replaceFileName($i["name"])?> > 
   <!-- <a href ="./case_images/Chroma%2520Case.png"> -->
     
        <div class="case-wrap" data-id="<?=$i["_id"]?>" id="<?=$i["url"]?>">
          <div class="case-name"><?=$i["name"]?></div>
          <div class="case-price">Price: <?=$i["median_price"]?></div>
          <img src=<?php replaceFileName($i["name"])?>>
        </div>
      </a>
      <?php }
      
    ?></div>


  <footer>

    <h1>About</h1>
  </footer>
</body>

</html>
