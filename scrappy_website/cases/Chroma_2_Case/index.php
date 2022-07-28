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
    $caseObj = queryCurrentCase("Chroma Case");
    $currentPrice = $caseObj["lowest_price"];
    $currentVolume = $caseObj["volume"];
    $phpArray = queryCaseData("Chroma Case",1,48);
    $phpPriceArray=[];
    $phpDateArray=[];
    
    for($i= 0;$i<count($phpArray);$i++){
        array_push($phpPriceArray,$phpArray[$i][0]);
        array_push($phpDateArray,$phpArray[$i][1]);
    }
    echo "var currentPrice = '". $currentPrice . "';";
    echo "var currentVolume = '". $currentVolume."';";
    echo " var jsPriceArray = ". json_encode($phpPriceArray) . ";";
    echo " var jsDateArray =" . json_encode($phpDateArray) . ";";
    ?>;
    var ctx;
    var myChart;
    for(var i= 0;i<jsPriceArray.length;i++){
                jsDateArray[i] = jsDateArray[i].substring(5,19);
        
                jsPriceArray[i]=jsPriceArray[i].substring(1);
                
            }
     try{
            mychart.destroy();
        }catch(exception_var){
            console.log("Truly lazy.");
        }
       
         
    function chart(relative){
        ctx = document.getElementById('priceChart').getContext('2d');
            
        myChart = new Chart(ctx, {
            type: 'line',
            data: {
        //labels: ['12:00','1:00','2:00','3:00','4:00','5:00','6:00','7:00','8:00','9:00','10:00','11:00'],
                labels:jsDateArray,
                datasets: [{
                label: 'USD',
                data:jsPriceArray,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.6)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)'
                ],
                pointBackgroundColor: ['rgba(255,99,132,1)'],
                fill:true,
                borderWidth: 2
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero:relative
                }
            }
        }
    });

        }
        function changeGraphMode(){
        myChart.beginAtZero=true;
            myChart.update();
    }   
  </script>
</head>

<body>
    <script src="https://cdn.jsdelivr.net/npm/chart.js@3.8.0/dist/chart.min.js"></script>
    <header id="header">Chroma 2 Case</header>
    <p id = "price"></p>
    <div id="chart_div">
        <canvas id="priceChart" >
            <p>chart</p>
        </canvas>
    </div>
    <button onclick="changeGraphMode()">settings</button>
    <p id="stats"></p>   
    <script>
        chart(true);
        var p = document.getElementById("stats");


        p.innerHTML = "Lowest Price:"+currentPrice+"<br> Volume:"+currentVolume;
        
</script>

</body>

</html>
