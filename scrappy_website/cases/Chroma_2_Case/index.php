<!DOCTYPE html>
<html>

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width">
  <title>CS:GO Case Prices</title>
  <link rel="icon" type="image/x-icon" href="./favicon.ico?">
  <link href="./style.css" rel="stylesheet" type="text/css" />
    <script src="https://cdn.jsdelivr.net/npm/chart.js@3.8.0/dist/chart.min.js">
    <script src="./script.js"></script>
</head>

<body>
  
  <header>csgo case price viewer.</header>


    <canvas id = "chart" width = "400" height= "400"></canvas>
    <script>
        const ctx = document.getElementById("chart");
        const graph = new Chart(ctx,
        type:'line',
        data:{
            datasets: [{
            data: [{x: 10, y: 20}, {x: 15, y: null}, {x: 20, y: 10}]
            }]
        });
    </script>


  <footer>

    
    <p>Case Prices Last Updated: <?php require "scrappy_website_db.php"; echo $date;?></p>
    <a href = "./about.html"><p>About</p></a>
    <a href ="https://github.com/zbrianhuang/cscaseprice"><p>Github</p></a>
  </footer>
</body>

</html>
