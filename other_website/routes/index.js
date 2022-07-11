var express = require('express');
var router = express.Router();
const { MongoClient } = require('mongodb');
//const client = new MongoClient("mongodb+srv://reader:ZmMsImV62pqjB544@cluster0.pattjaw.mongodb.net/test");
/*MongoClient.connect(url, function(err, db) {
  if (err) throw err;
  var dbo = db.db("mydb");
  dbo.collection("CasePriceData").find().skip(dbo,count()-33).toArray(function(err, result) {
    if (err) throw err;
    console.log(result);
    db.close();
  });
});
*/
/* GET home page. */
router.get('/', function(req, res, next) {
  var a = 10;
  res.render('index', { title:'Scrappy',unga: a});
  
});
//ZmMsImV62pqjB544
module.exports = router;
