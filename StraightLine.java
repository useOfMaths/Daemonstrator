package dymetric;

import java.awt.*;

public class StraightLine extends Canvas {

    protected Color ball_colour;
    protected int x1 = 50;
    protected int x2 = 800;
    protected int y1 = 50;
    protected int y2 = 300;
    protected int x = x1;
    protected int y = y1;
    protected double m, c; // slope and y-intercept of a straight line
    protected final int aWIDTH, aHEIGHT;

    public StraightLine() {
        setBackground(Color.LIGHT_GRAY); // canvas color
        ball_colour = Color.RED;
        aWIDTH = aHEIGHT = 10;

        m = (double) (y2 - y1) / (x2 - x1); // slope
        c = (double) (x2 * y1 - x1 * y2) / (x2 - x1); // y-intercept

    }

    // Feel free to double buffer if flickering occurs
    public void paint(Graphics g) {
        g.setColor(ball_colour);
        // draw a dot
        g.fillOval(x, y, aWIDTH, aHEIGHT);
    }

    public void moveInLine() {
        // condition for continuing motion
        while (x <= 700) {
            y = (int) Math.ceil(m * x + c);
            paint(this.getGraphics());
            
            x += 10;
            // introduce a delay betweeen renderings
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
            }
        }
    }
}
