var URL="https://api.openweathermap.org/data/2.5/forecast?lat=";
var key="&units=imperial&appid=5e12139d571de5e6d6bd757598f111b9";

var URLTOMTOM="https://api.tomtom.com/search/2/search/";
var TOMTOMKey=".json?radius=1000&minFuzzyLevel=1&maxFuzzyLevel=2&view=Unified&relatedPois=off&key=p3sdhDHasavfYa1qqbsWMXDFPvOmTUcK";

var URLDatabase="http://172.17.14.10/final.php?method=setWeather";
var URLGetDatabase="http://172.17.14.10/final.php?method=getWeather&date=";

function getLatLong() {
 var search=document.getElementById("location").value;
 a=$.ajax({
 url: URLTOMTOM + search + TOMTOMKey,
 method: "GET"
 }).done(function(data) {
  lat = data.results[0].position.lat;
  long = data.results[0].position.lon;
  getWeather(search, lat, long);
 }).fail(function(error) {
  console.log(error);
 });

}

function putDatabase(search, lati, long, weather) {
 var weatherI = JSON.stringify(weather);
 var location = [lati, long];
 var locationI = JSON.stringify(location);
 a=$.ajax({
 url: URLDatabase,
 method: "POST",
 data: {Location: search, MapJson: locationI, WeatherJson: weatherI}
 }).done(function(data) {
  console.log("success");
 }).fail(function(error) {
  console.log(error);
 });
}

function getWeather(search, lati, long) {
 a=$.ajax({
 url: URL + lati + "&lon=" + long + key,
 method: "GET"
 }).done(function(data) {
  var time = 4;
  for (let i=0;i<=time;i++) {
   var date = data.list[i*8].dt_txt;
   var dateFinal = date.toString().slice(5, 10);
   $("#date" + i).html(dateFinal);
   //var year = 2022;
   //var dayOfWeek = new Date(+year, getDate[1] - 1, getDate[2] + i);
   //var day = dayOfWeek.toString().slice(0, 3);
   var unixTime = data.list[i*8].dt;
   var dayOfWeek = new Date(unixTime * 1000);
   var day = dayOfWeek.toString().slice(0, 3);
   var high = data.list[i*8].main.temp_max;
   var low = data.list[i*8].main.temp_min;
   var humidity = data.list[i*8].main.humidity;
   var visibility = data.list[i*8].visibility;
   var forecastDesc = data.list[i*8].weather[0].description;
   $("#day" + i).html(day);
   $("#high" + i).html(high);
   $("#low" + i).html(low);
   $("#humidity" + i).html(humidity);
   $("#visibility" + i).html(visibility);
   $("#forecastDesc" + i).html(forecastDesc);
   $("#forecastIcon" + i).attr("src", "http://openweathermap.org/img/wn/" + data.list[i*8].weather[0].icon + "@2x.png");
   var weatherInfo = [dateFinal, day, high, low, humidity, visibility, forecastDesc];
   putDatabase(search, lati, long, weatherInfo);
  }
 }).fail(function(error) {
  console.log(error);
 });
}

function getDatabase() {
 var date = document.getElementById("historicDate").value;
 var lines = document.getElementById("historicLines").value;
 console.log(date);
 console.log(lines);
 a=$.ajax({
 url: URLGetDatabase + date,
 method: "GET"
 }).done(function(data) {
  var total = data.result.length;
  for (let i=0;i<total && i<lines;i++) {
   $("#dateTime" + i).html(data.result[i].DateTime);
   $("#locationSearch" + i).html(data.result[i].Location);
   $("#mapJson" + i).html(data.result[i].MapJson);
   $("#weatherJson" + i).html(data.result[i].WeatherJson);
  }
 }).fail(function(error) {
  console.log(error);
 });
}
