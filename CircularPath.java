package dymetric;

import java.awt.*;

public class CircularPath extends Canvas {

    protected Color ball_colour;
    //circle coordinates
    protected int a = 250;
    protected int b = 165;
    protected final int r = 150;
    protected int x = a - r;
    protected int y = b;
    protected final int aWIDTH, aHEIGHT;

    public CircularPath() {
        setBackground(Color.LIGHT_GRAY); // canvas color
        ball_colour = Color.RED;
        aWIDTH = aHEIGHT = 10;
    }

    // Feel free to double buffer if flickering occurs
    public void paint(Graphics g) {
        g.setColor(ball_colour);
        // draw a dot
        g.fillOval(x, y, aWIDTH, aHEIGHT);
    }

    public void moveCyclic() {
        // condition for continuing motion
        while (x <= a + r) {
            y = b - (int) Math.round(Math.sqrt(Math.pow(r, 2) - Math.pow((x - a), 2)));
            paint(this.getGraphics());

            y = b + (int) Math.round(Math.sqrt(Math.pow(r, 2) - Math.pow((x - a), 2)));
            paint(this.getGraphics());
            
            x += 20;
            // introduce a delay betweeen renderings
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
            }
        }
    }
}
