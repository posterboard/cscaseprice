<!DOCTYPE html>
<html>
<!-- asldfjal;sdkfj;als!-->
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
  <div id="list-of-cases">
      <?php 
      require "scrappy_website_db.php";
      foreach ($case as $i) { 
        ?>
      <a href=<?php echo "./sub_pages/blank.txt" ?> >
        <div class="case-wrap" data-id="<?=$i["_id"]?>">
          <div class="case-name"><?=$i["name"]?></div>
          <div class="case-price">Price: <?=$i["lowest_price"]?></div>
        </div>
      </a>
      <?php }
      
    ?></div>


  <footer>

    <h1>About</h1>
  </footer>
</body>

</html>
