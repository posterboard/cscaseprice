
var listOfCases = document.getElementById('list-of-cases').getElementsByTagName('price');

for (var i = 0;i<listOfCases.length;i++) {
    //loop runs throughh
    listOfCases[i].innerHTML=calculatePriceChange(listOfCases[i].getAttribute("past_price"),listOfCases[i].getAttribute("current_price"));
}
function calculatePriceChange(oldPrice,newPrice){

    var oldDouble = parseFloat(removeDollarSign(oldPrice));
    var newDouble = parseFloat(removeDollarSign(newPrice));

    var pricechange= ((oldDouble-newDouble)/oldDouble)*100;

    var roundedPrice = Math.round(pricechange*1000)/1000;
    if(roundedPrice<0){
        return roundedPrice+"%";
    }else if (roundedPrice>0){
        return "+"+roundedPrice+"%";
    }else{
        return roundedPrice+"%";
    }
}
function removeDollarSign(input){
    var output = input.substring(1,input.length);

    return output;
}