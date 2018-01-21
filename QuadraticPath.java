package dymetric;

import java.awt.*;

public class QuadraticPath extends Canvas {

    protected Color ball_colour;
    protected int x_start = 50;
    protected int y_start = 300;
    protected int x_max = 350;
    protected int y_max = 50;
    protected int x = x_start;
    protected int y = y_start;
    protected double a, b, c; // coefficients and constant
    protected final int aWIDTH, aHEIGHT;

    public QuadraticPath() {
        setBackground(Color.LIGHT_GRAY); // canvas color
        ball_colour = Color.RED;
        aWIDTH = aHEIGHT = 10;

        // constants
        a = (double)(y_start - y_max) / Math.pow((x_start - x_max), 2);
        b = -2 * a * x_max;
        c = y_max + a * Math.pow(x_max, 2);

    }

    // Feel free to double buffer if flickering occurs
    public void paint(Graphics g) {
        g.setColor(ball_colour);
        // draw a dot
        g.fillOval(x, y, aWIDTH, aHEIGHT);
    }

    public void moveQuadratic() {
        // condition for continuing motion
        while (x <= 750 && y <= y_start) {
            paint(this.getGraphics());
            
            x += 10;
            y = (int)Math.round(a*x*x + b*x + c);
            // introduce a delay betweeen renderings
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
            }
        }
    }
}
