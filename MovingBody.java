package dymetric;

import java.awt.*;

public class MovingBody extends Canvas {

    protected Color ball_colour;
    protected int x = 10;
    protected int y = 110;
    protected final int aWIDTH, aHEIGHT;

    public MovingBody() {
        setBackground(Color.LIGHT_GRAY); // canvas color
        ball_colour = Color.RED;
        aWIDTH = aHEIGHT = 80;
    }

    public void paint(Graphics g) {
        // erase previous circle
        g.clearRect(x - 10, y, aWIDTH, aHEIGHT);

        g.setColor(ball_colour);
        // draw a circle
        g.fillOval(x, y, aWIDTH, aHEIGHT);
    }

    public void doGlide() {
        // condition for continuing motion
        while (x <= 670) {
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
