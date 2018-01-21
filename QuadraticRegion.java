package dymetric;

import java.awt.*;

public class QuadraticRegion extends Canvas {

    Color ball_colour;
    // coordinates for the ball(circle)
    protected int x_ball = 50;
    protected int y_ball = 100;
    protected int previous_x = x_ball;
    protected int previous_y = y_ball;
    protected final int ballWIDTH, ballHEIGHT;

    protected int xq_start = 300;
    protected int yq_start = 50;
    protected int xq_min = 450;
    protected int yq_min = 300;
    protected double xq_lb;
    protected double xq_ub;
    protected int xq_stop = 600;
    protected int x = xq_start;
    protected int y = yq_start;
    protected double a, b, c; // coefficients and constant
    protected double discriminant;
    protected final int aWIDTH, aHEIGHT;

    public QuadraticRegion() {
        setBackground(Color.LIGHT_GRAY); // canvas color
        ball_colour = Color.YELLOW;
        aWIDTH = aHEIGHT = 5;

        // constants
        a = (double) (yq_start - yq_min) / Math.pow((xq_start - xq_min), 2);
        b = -2 * a * xq_min;
        c = yq_min + a * Math.pow(xq_min, 2);

        ballWIDTH = ballHEIGHT = 100;

        discriminant = Math.sqrt(b * b - 4 * a * (c - (y_ball+(double)(ballHEIGHT/2))));
        if (a < 0) {// a is negative
            xq_lb = (double)(-b + discriminant) / (2 * a); // upper boundary
            xq_ub = (double)(-b - discriminant) / (2 * a); // lower boundary
        } else {
            xq_lb = (double)(-b - discriminant) / (2 * a); // lower boundary
            xq_ub = (double)(-b + discriminant) / (2 * a); // upper boundary
        }
    }

    // Feel free to double buffer if flickering occurs
    public void paint(Graphics g) {
        //draw quadratic curve
        g.setColor(Color.BLACK);
        for (; x < xq_stop; x++) {
            // redraw dot
            y = (int) Math.round(a * x * x + b * x + c);
            g.fillOval(x, y, aWIDTH, aHEIGHT);
        }
        x = xq_start;

        // erase previous circle
        g.setColor(Color.LIGHT_GRAY);
        g.fillOval(previous_x, previous_y, ballWIDTH, ballHEIGHT);
        g.setColor(ball_colour);
        // draw a circle
        g.fillOval(x_ball, y_ball, ballWIDTH, ballHEIGHT);
        previous_x = x_ball;
        previous_y = y_ball;
    }

    public void checkBoundary() {
        // condition for continuing motion
        while (x_ball <= 630) {
            if ((x_ball <= xq_lb && x_ball+ballWIDTH >= xq_lb)
                    || (x_ball <= xq_ub && x_ball + ballWIDTH >= xq_ub)) {
                ball_colour = Color.RED; // trespassing color for our moving body(circle)
            } else if (x_ball >= xq_lb && x_ball + ballWIDTH <= xq_ub) {
                ball_colour = Color.GREEN; // zone color for our moving body(circle)
            } else {
                ball_colour = Color.YELLOW; // out of zone color for our moving body(circle)
            }
            paint(this.getGraphics());
            
            x_ball += 5;
            // introduce a delay betweeen renderings
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
            }
        }
    }
}
