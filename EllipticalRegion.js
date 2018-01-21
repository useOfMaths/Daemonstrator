var canvas = document.getElementById("ellipse_region");
var context = canvas.getContext("2d");
context.fillStyle = "#888888"; // color for our moving body(circle)

// coordinates for the square
var x_square = 10;
var y_square = 250;
var sq_length = 100;
// draw the square
context.fillRect(x_square, y_square, sq_length, sq_length);

//elliptical coordinates
var h = 350; // vertice
var k = 225; // vertice
var a = 200; // major axis
var b = 150; // minor axis
var x = h - a;
var y = k;

//draw ellipse
for (; x < h + a; x++) {
    y = k - (b / a) * Math.sqrt(Math.pow(a, 2) - Math.pow((x - h), 2));
    context.beginPath();
    context.arc(x, y, 1, 0, 2 * Math.PI);
    context.fill();

    y = k + (b / a) * Math.sqrt(Math.pow(a, 2) - Math.pow((x - h), 2));
    context.beginPath();
    context.arc(x, y, 1, 0, 2 * Math.PI);
    context.fill();
}

function ellipsedSquare() {
    // condition for continuing motion
    if (x_square + sq_length < 600) {
        context.clearRect(x_square - 10, y_square, sq_length, sq_length); // erase previous circle

        var square_left = x_square;
        var square_right = x_square + sq_length;
        var square_top = y_square;
        var square_bottom = y_square + sq_length;

        // determinants for each side of the square
        var x_left_det = (b / a) * Math.sqrt(Math.pow(a, 2) - Math.pow((square_left - h), 2));
        var x_right_det = (b / a) * Math.sqrt(Math.pow(a, 2) - Math.pow((square_right - h), 2));
        var y_up_det = (a / b) * Math.sqrt(Math.pow(b, 2) - Math.pow((square_top - k), 2));
        var y_down_det = (a / b) * Math.sqrt(Math.pow(b, 2) - Math.pow((square_bottom - k), 2));

        if (square_top > k - x_left_det && square_bottom < k + x_left_det &&
                square_top > k - x_right_det && square_bottom < k + x_right_det &&
                square_left > h - y_up_det && square_right < h + y_up_det &&
                square_left > h - y_down_det && square_right < h + y_down_det) {
            context.fillStyle = "#00ff00"; // color for our moving body(circle)
        } else {
            context.fillStyle = "#888888"; // color for our moving body(circle)
        }

        // redraw square
        context.fillRect(x_square, y_square, sq_length, sq_length);

        x_square += 10;
        clr_obj = setTimeout(function () {
            ellipsedSquare();
        }, 100);
    }
}