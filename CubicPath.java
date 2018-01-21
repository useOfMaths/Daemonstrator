package dymetric;

import java.awt.*;

public class CubicPath extends Canvas {

    protected Color ball_colour;
    protected int x_start = 50;
    protected int x_max = 200;
    protected int y_max = 10;
    protected int x_min = 500;
    protected int y_min = 310;
    protected int x = x_start;
    protected int y;
    protected double a, b, c, d; // coefficients and constant
    protected final int aWIDTH, aHEIGHT;

    public CubicPath() {
        setBackground(Color.LIGHT_GRAY); // canvas color
        ball_colour = Color.RED;
        aWIDTH = aHEIGHT = 10;

        // constants
        a = (double) (-2 * (y_max - y_min)) / Math.pow((x_max - x_min), 3);
        b = -((double) 3 / 2) * a * (x_max + x_min);
        c = 3 * a * x_max * x_min;
        d = y_max + ((double) a / 2) * (x_max - 3 * x_min) * Math.pow(x_max, 2);

        y = (int)Math.round(a * Math.pow(x, 3) + b * Math.pow(x, 2) + c * x + d);
    }

    // Feel free to double buffer if flickering occurs
    public void paint(Graphics g) {
        g.setColor(ball_colour);
        // draw a dot
        g.fillOval(x, y, aWIDTH, aHEIGHT);
    }

    public void moveCubic() {
        // condition for continuing motion
        while (x <= 750 && y >= y_max) {
            paint(this.getGraphics());
            
            x += 20;
            y = (int)Math.round(a * Math.pow(x, 3) + b * Math.pow(x, 2) + c * x + d);
            // introduce a delay betweeen renderings
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
            }
        }
    }
}
