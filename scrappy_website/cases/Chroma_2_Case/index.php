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
  <script src="https://cdn.jsdelivr.net/npm/chart.js@3.8.0/dist/chart.min.js"></script>
  <header>csgo case price viewer.</header>

  <canvas id="myChart" width="400" height="400"></canvas>
    
<script>
    <?php 
    require "../case_query.php";
    //$phpPriceArray = json_encode(queryCaseData("Chroma Case",1,48));
    $phpArray = queryCaseData("Chroma Case",1,48);
    $phpPriceArray=[];
    $phpDateArray=[];
    for($i= 0;$i<count($phpArray);$i++){
        array_push($phpPriceArray,$phpArray[$i][0]);
        array_push($phpDateArray,$phpArray[$i][1]);
    }
    echo " var jsPriceArray = ". json_encode($phpPriceArray) . ";";
    echo " var jsDateArray =" . json_encode($phpDateArray) . ";";
    ?>;

    /*
    for(var i= 0;i<jsPriceArray.length;i++){
        strBuilder+="'"+jsPriceArray[i].substring(1)+"',";
    }
    var a = strBuilder.substring(0,strBuilder.length-1);
    a+="]";
    */
    var xAxis = [];
    for(var i= 0;i<jsPriceArray.length;i++){
        jsPriceArray[i]=jsPriceArray[i].substring(1);
        xAxis.push(i);
    }
    const ctx = document.getElementById('myChart').getContext('2d');
    const myChart = new Chart(ctx, {
    type: 'line',
    data: {
        //labels: ['12:00','1:00','2:00','3:00','4:00','5:00','6:00','7:00','8:00','9:00','10:00','11:00'],
        labels:jsDateArray,
        datasets: [{
            label: 'USD',
            data:jsPriceArray,
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});
</script>


</body>

</html>
