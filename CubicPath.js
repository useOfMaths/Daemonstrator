
var canvas = document.getElementById("cube_path");
var context = canvas.getContext("2d");
context.fillStyle = "#888888"; // color for our moving body(circle)

var x_max = 150;
var y_max = 50;
var x_min = 350;
var y_min = 350;

// constants
var a = -2 * (y_max - y_min) / Math.pow((x_max - x_min), 3);
var b = -(3 / 2) * a * (x_max + x_min);
var c = 3 * a * x_max * x_min;
var d = y_max + (a / 2) * (x_max - 3 * x_min) * Math.pow(x_max, 2);

var x_start = 50;
var x = x_start;
var y = a * Math.pow(x, 3) + b * Math.pow(x, 2) + c * x + d;

// draw a dot
context.beginPath();
context.arc(x, y, 5, 0, 2 * Math.PI);
context.fill();

var x_stop = 450;
function moveCubic() {
    // condition for continuing motion
    if (x <= x_stop) {
        y = a * Math.pow(x, 3) + b * Math.pow(x, 2) + c * x + d;

        // redraw dot
        context.beginPath();
        context.arc(x, y, 5, 0, 2 * Math.PI);
        context.fill();

        x += 20;
        setTimeout(function () { moveCubic(); }, 100);
    }
}