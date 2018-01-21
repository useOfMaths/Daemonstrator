var canvas = document.getElementById("quad_region");
var context = canvas.getContext("2d");
context.fillStyle = "#888888"; // color for our moving body(circle)

// coordinates for the ball(circle)
var x_ball = 50;
var y_ball = 150;
var radius = 40;
// draw the circle
context.beginPath();
context.arc(x_ball, y_ball, radius, 0, 2 * Math.PI);
context.fill();

//quadratic coordinates
var xq_start = 200;
var yq_start = 50;
var xq_min = 350;
var yq_min = 300;
var xq_stop = 500;

var a = (yq_start - yq_min) / Math.pow((xq_start - xq_min), 2);
var b = -2 * a * xq_min;
var c = yq_min + a * Math.pow(xq_min, 2);

//draw quadratic curve
var x = xq_start;
var y = yq_start;
for (; x < xq_stop; x += 1) {
    // redraw dot
    y = a * x * x + b * x + c;
    context.beginPath();
    context.arc(x, y, 1, 0, 2 * Math.PI);
    context.fill();
}

var discriminant = Math.sqrt(b * b - 4 * a * (c - y_ball));
var xq_lb;
var xq_ub;
if (a < 0) {// a is negative
    xq_lb = (-b + discriminant) / (2 * a); // upper boundary
    xq_ub = (-b - discriminant) / (2 * a); // lower boundary
} else {
    xq_lb = (-b - discriminant) / (2 * a); // lower boundary
    xq_ub = (-b + discriminant) / (2 * a); // upper boundary
}

var clr_obj;
function doGlide() {
    // condition for continuing motion
    if (x_ball <= 540) {
        context.clearRect(x_ball - radius - 10, y_ball - radius, 80, 80); // erase previous circle
        if ((x_ball - radius <= xq_lb && x_ball + radius >= xq_lb)
                || (x_ball - radius <= xq_ub && x_ball + radius >= xq_ub)) {
            context.fillStyle = "#ff0000"; // trespaaing color for our moving body(circle)
        } else if (x_ball - radius >= xq_lb && x_ball + radius <= xq_ub) {
            context.fillStyle = "#00ff00"; // zone color for our moving body(circle)
        } else {
            context.fillStyle = "#888888"; // out of zone color for our moving body(circle)
        }
        // redraw circle
        context.beginPath();
        context.arc(x_ball, y_ball, radius, 0, 2 * Math.PI);
        context.fill();

        x_ball += 10;
        clr_obj = setTimeout(function () { doGlide(); }, 100);
    }
}