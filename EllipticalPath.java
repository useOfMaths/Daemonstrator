package dymetric;

import java.awt.*;

public class EllipticalPath extends Canvas {

    protected Color ball_colour;
    //ellipse coordinates
    protected int h = 250;
    protected int k = 175;
    protected int a = 150;
    protected int b = 100;
    protected int x = h - a;
    protected int y = k;
    protected final int aWIDTH, aHEIGHT;

    public EllipticalPath() {
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

    public void moveElliptic() {
        // condition for continuing motion
        while (x <= h + a) {
            y = (int)Math.round(k - ((double)b / a) * Math.sqrt(Math.pow(a, 2) - Math.pow((x - h), 2)));
            paint(this.getGraphics());

            y = (int)Math.round(k + ((double)b / a) * Math.sqrt(Math.pow(a, 2) - Math.pow((x - h), 2)));
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
