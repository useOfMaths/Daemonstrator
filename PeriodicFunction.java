package dymetric;

import java.awt.*;

public class PeriodicFunction extends Canvas {

    protected Color ball_colour;
    protected int theta = 0;
    protected int a = 100; // constant
    protected int y;
    protected final int aWIDTH, aHEIGHT;

    public PeriodicFunction() {
        setBackground(Color.LIGHT_GRAY); // canvas color
        ball_colour = Color.RED;
        aWIDTH = aHEIGHT = 10;

        // convert theta from degree to radians
        y = (int) Math.round(a * Math.sin(theta * (double) Math.PI / 180));
    }

    // Feel free to double buffer if flickering occurs
    public void paint(Graphics g) {
        g.translate(0, 150);
        
        g.setColor(ball_colour);
        // draw a dot
        g.fillOval(theta, y, aWIDTH, aHEIGHT);
    }

    public void moveSinusoidal() {
        // condition for continuing motion
        while (theta < 750) {
            y = (int) Math.round(a * Math.sin(theta * (double) Math.PI / 180));
            paint(this.getGraphics());
            
            theta += 15;
            // introduce a delay betweeen renderings
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
            }
        }
    }
}
