package dymetric;

import java.awt.*;

public class StraightLineRegion extends Canvas {

    protected Color ball_colour;
    // coordinates for the ball(circle)
    protected int x_ball = 50;
    protected int y_ball = 100;
    protected int previous_x = x_ball;
    protected int previous_y = y_ball;

    protected int x1 = 400;
    protected int x2 = 600;
    protected int y1 = 310;
    protected int y2 = 10;
    // x-coordinate for diagonal line
    protected double x_line;
    protected double m, c; // slope and y-intercept of a straight line
    protected final int aWIDTH, aHEIGHT;

    public StraightLineRegion() {
        setBackground(Color.LIGHT_GRAY); // canvas color
        ball_colour = Color.YELLOW;
        aWIDTH = aHEIGHT = 80;

        m = (double) (y2 - y1) / (x2 - x1); // slope
        c = (double) (x2 * y1 - x1 * y2) / (x2 - x1); // y-intercept

        x_line = (double) (y_ball - c) / m;
    }

    // Feel free to double buffer if flickering occurs
    public void paint(Graphics g) {
        //draw diagonal line
        g.setColor(Color.BLACK);
        g.drawLine(x1, y1, x2, y2);
        
        // erase previous circle
        g.setColor(Color.LIGHT_GRAY);
        g.fillOval(previous_x, previous_y, aWIDTH, aHEIGHT);
        g.setColor(ball_colour);
        // draw a circle
        g.fillOval(x_ball, y_ball, aWIDTH, aHEIGHT);
        previous_x = x_ball;
    }

    public void checkBoundary() {
        // condition for continuing motion
        while (x_ball <= 650) {
            if (x_ball >= x_line) {
                ball_colour = Color.GREEN; // color for our moving body(circle)
            }
            paint(this.getGraphics());
            
            x_ball += 10;
            // introduce a delay betweeen renderings
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
            }
        }
    }
}
