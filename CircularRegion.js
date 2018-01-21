var canvas = document.getElementById("circle_region");
var context = canvas.getContext("2d");
context.fillStyle = "#888888"; // color for our moving body(circle)

// coordinates for the square
var x_square = 10;
var y_square = 250;
var sq_length = 100;
// draw the square
context.fillRect(x_square, y_square, sq_length, sq_length);

//circle coordinates
var a = 300;
var b = 225;
var r = 150; // radius
//draw circle
context.beginPath();
context.arc(a, b, r, 0, 2 * Math.PI);
context.stroke();

function circledSquare() {
    // condition for continuing motion
    if (x_square + sq_length < 600) {
        context.clearRect(x_square - 10, y_square, sq_length, sq_length); // erase previous square

        var square_left = x_square;
        var square_right = x_square + sq_length;
        var square_top = y_square;
        var square_bottom = y_square + sq_length;
        // determinants for each side of the square
        var x_left_det = Math.sqrt(Math.pow(r, 2) - Math.pow((square_left - a), 2));
        var x_right_det = Math.sqrt(Math.pow(r, 2) - Math.pow((square_right - a), 2));
        var y_up_det = Math.sqrt(Math.pow(r, 2) - Math.pow((square_top - b), 2));
        var y_down_det = Math.sqrt(Math.pow(r, 2) - Math.pow((square_bottom - b), 2));

        // check the bounds of the circle
        if (square_top > b - x_left_det && square_bottom < b + x_left_det &&
                square_top > b - x_right_det && square_bottom < b + x_right_det &&
                square_left > a - y_up_det && square_right < a + y_up_det &&
                square_left > a - y_down_det && square_right < a + y_down_det) {
            context.fillStyle = "#00ff00"; // color for our moving body(square) inside our circle
        } else {
            context.fillStyle = "#888888"; // color for our moving body(square) outside our circle
        }

        // redraw square
        context.fillRect(x_square, y_square, sq_length, sq_length);

        x_square += 10;
        clr_obj = setTimeout(function () {
            circledSquare();
        }, 100);
    }
}