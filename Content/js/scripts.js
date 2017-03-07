// // <canvas id="canvas" width="300" height="300"></canvas>
// var canvas = document.getElementById("canvas");
// var ctx = canvas.getContext("2d");
// ctx.fillStyle = "gold";
//
// var fillUp = 300;
// var tall = 1;
//
// setInterval(function() {
//   ctx.clearRect(0, 0, 300, 300);
//   ctx.fillRect(0, fillUp, 300, tall);
//
//   tall++;
//   fillUp--;
//   if(fillUp < 0) {
//     fillUp = 300;
//   }
//   if(tall > 300) {
//     tall = 0;
//   }
// }, 30);


$(document).ready(function() {
    var pitchers;
    var costPerPitcher;
    var playerMoney = parseInt($("#player-money").text());
    $('input.pitcher').click(function() {
        pitchers = parseInt($('input.pitcher').val());
        costPerPitcher = parseInt($("#pitcher-price").text());
        if(pitchers > 0)
        {
            newMoney = playerMoney - (costPerPitcher * pitchers);
            $("#player-money").text(newMoney);
            console.log(costPerPitcher);
            console.log(pitchers);
        }
    });

    $("[type='number']").keypress(function (evt) {
    evt.preventDefault();
    });


});
