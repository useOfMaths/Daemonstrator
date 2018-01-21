package dymetric;

import java.awt.*;

public class EllipticalRegion extends Canvas {

    protected Color sq_colour;
    // coordinates for the ball(circle)
    protected int x_square = 10;
    protected int y_square = 150;
    protected int previous_x = x_square;
    protected int previous_y = y_square;
    protected final int sqLENGTH = 100;

    //ellipse coordinates
    protected int h = 350; // vertice
    protected int k = 175; // vertice
    protected final int a = 200; // major axis
    protected final int b = 125; // minor axis
    protected int x = h - a;
    protected int y = k - b;

    public EllipticalRegion() {
        setBackground(Color.LIGHT_GRAY); // canvas color
        sq_colour = Color.YELLOW;
    }

    // Feel free to double buffer if flickering occurs
    public void paint(Graphics g) {
        // draw an ellipse
        g.drawOval(x, y, 2*a, 2*b);

        g.clearRect(previous_x, previous_y, sqLENGTH, sqLENGTH); // erase previous square
        // draw square
        g.setColor(sq_colour);
        g.fillRect(x_square, y_square, sqLENGTH, sqLENGTH);
        previous_x = x_square;
        previous_y = y_square;
    }

    public void ellipsedSquare() {
        // condition for continuing motion
        while (x_square + sqLENGTH < 750) {
            int square_left = x_square;
            int square_right = x_square + sqLENGTH;
            int square_top = y_square;
            int square_bottom = y_square + sqLENGTH;

            // determinants for each side of the square
            int x_left_det = (int) Math.round(((double) b / a)
                    * Math.sqrt(Math.pow(a, 2) - Math.pow((square_left - h), 2)));
            int x_right_det = (int) Math.round(((double) b / a)
                    * Math.sqrt(Math.pow(a, 2) - Math.pow((square_right - h), 2)));
            int y_up_det = (int) Math.round(((double) a / b)
                    * Math.sqrt(Math.pow(b, 2) - Math.pow((square_top - k), 2)));
            int y_down_det = (int) Math.round(((double) a / b)
                    * Math.sqrt(Math.pow(b, 2) - Math.pow((square_bottom - k), 2)));

            if (square_top > k - x_left_det && square_bottom < k + x_left_det
                    && square_top > k - x_right_det && square_bottom < k + x_right_det
                    && square_left > h - y_up_det && square_right < h + y_up_det
                    && square_left > h - y_down_det && square_right < h + y_down_det) {
                sq_colour = Color.GREEN; // color for our moving body(square) inside our ellipse
            } else {
                sq_colour = Color.YELLOW; // color for our moving body(square) outside our ellipse
            }

            paint(this.getGraphics());
            
            x_square += 10;
            // introduce a delay betweeen renderings
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
            }
        }
    }
}
