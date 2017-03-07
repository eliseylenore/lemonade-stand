// <canvas id="canvas" width="300" height="300"></canvas>
var canvas = document.getElementById("canvas");
var ctx = canvas.getContext("2d");
ctx.fillStyle = "gold";

var fillUp = 300;
var tall = 1;

setInterval(function() {
  ctx.clearRect(0, 0, 300, 300);
  ctx.fillRect(0, fillUp, 300, tall);

  tall++;
  fillUp--;
  if(fillUp < 0) {
    fillUp = 300;
  }
  if(tall > 300) {
    tall = 0;
  }
}, 30);
