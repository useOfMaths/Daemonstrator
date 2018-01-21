package dymetric;

import java.awt.*;

public class CircularRegion extends Canvas {

    protected Color sq_colour;
    // coordinates for the ball(circle)
    protected int x_square = 10;
    protected int y_square = 150;
    protected int previous_x = x_square;
    protected int previous_y = y_square;
    protected final int sqLENGTH = 100;

    //circle coordinates
    protected int a = 300;
    protected int b = 175;
    protected final int r = 150;
    protected double discriminant;

    public CircularRegion() {
        setBackground(Color.LIGHT_GRAY); // canvas color
        sq_colour = Color.YELLOW;
    }

    // Feel free to double buffer if flickering occurs
    public void paint(Graphics g) {
        // draw a circle
        g.drawOval(a - r, b - r, 2 * r, 2 * r);

        g.clearRect(previous_x, previous_y, sqLENGTH, sqLENGTH); // erase previous square
        // draw square
        g.setColor(sq_colour);
        g.fillRect(x_square, y_square, sqLENGTH, sqLENGTH);
        previous_x = x_square;
        previous_y = y_square;
    }

    public void circledSquare() {
        // condition for continuing motion
        while (x_square + sqLENGTH < 750) {
            int square_left = x_square;
            int square_right = x_square + sqLENGTH;
            int square_top = y_square;
            int square_bottom = y_square + sqLENGTH;
            // determinants for each side of the square
            int x_left_det = (int) Math.round(Math.sqrt(Math.pow(r, 2) - Math.pow((square_left - a), 2)));
            int x_right_det = (int) Math.round(Math.sqrt(Math.pow(r, 2) - Math.pow((square_right - a), 2)));
            int y_up_det = (int) Math.round(Math.sqrt(Math.pow(r, 2) - Math.pow((square_top - b), 2)));
            int y_down_det = (int) Math.round(Math.sqrt(Math.pow(r, 2) - Math.pow((square_bottom - b), 2)));

            // check the bounds of the circle
            if (square_top > b - x_left_det && square_bottom < b + x_left_det
                    && square_top > b - x_right_det && square_bottom < b + x_right_det
                    && square_left > a - y_up_det && square_right < a + y_up_det
                    && square_left > a - y_down_det && square_right < a + y_down_det) {
                sq_colour = Color.GREEN; // color for our moving body(square) inside our circle
            } else {
                sq_colour = Color.YELLOW; // color for our moving body(square) outside our circle
            }

            paint(this.getGraphics());
            // introduce a delay betweeen renderings
            
            x_square += 10;
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
            }
        }
    }
}
