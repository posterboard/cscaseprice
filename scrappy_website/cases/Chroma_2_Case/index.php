<!DOCTYPE html>
<html>

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width">
  <title>Chroma 2 Case - CS:GO Case Prices</title>
  <link rel="icon" type="image/x-icon" href="../../favicon.ico?">
  <link href="../chart_style.css" rel="stylesheet" type="text/css" />
  <script src = "./price_chart.js"></script>
  <script>
    <?php 
    require "../case_query.php";
        //$phpPriceArray = json_encode(queryCaseData("Chroma Case",1,48));
    $currentPrice = queryCurrentPrice("Chroma Case");
    $phpArray = queryCaseData("Chroma Case",1,48);
    $phpPriceArray=[];
    $phpDateArray=[];
    for($i= 0;$i<count($phpArray);$i++){
        array_push($phpPriceArray,$phpArray[$i][0]);
        array_push($phpDateArray,$phpArray[$i][1]);
    }
    echo "var currentPrice = '". $currentPrice . "';";
    echo " var jsPriceArray = ". json_encode($phpPriceArray) . ";";
    echo " var jsDateArray =" . json_encode($phpDateArray) . ";";
    ?>;
function chart(){
            
            for(var i= 0;i<jsPriceArray.length;i++){
                jsDateArray[i] = jsDateArray[i].substring(5,19);
        
                jsPriceArray[i]=jsPriceArray[i].substring(1);
                
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
                    'rgba(255, 99, 132, 0.9)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)'
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
        }
  </script>
</head>

<body>
    <script src="https://cdn.jsdelivr.net/npm/chart.js@3.8.0/dist/chart.min.js"></script>
    <header id="header">Chroma 2 Case</header>
    <p id = "price"></p>
    <div id="chart_div">
        <canvas id="myChart" ></canvas>
    </div>
   
    <script>
        chart();
        var p = document.getElementById("price");


        p.innerHTML = currentPrice;
        
</script>

</body>

</html>
