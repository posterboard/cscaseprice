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
    <div class="header">
      <p>Case List</p>
      <input type="text" id="searchBar" placeholder="Search..">
    </div>    
  </navigation> 
  <h1 class="title">Case List:</h1>
 


  <footer>

    
    <p>Case Prices Last Updated: <?php require "scrappy_website_db.php"; echo $date;?></p>
    <a href = "./about.html"><p>About</p></a>
    <a href ="https://github.com/zbrianhuang/cscaseprice"><p>Github</p></a>
  </footer>
</body>

</html>
