package dymetric;

import java.awt.*;
import javax.swing.*;

public class Facet extends JFrame {
    
    private Container face;
    private CanvasFeel canvas;
    private ImageIcon logo;
    
    public Facet() {
        // Give our window a title
        super("A window that will hold a Canvas");
        // set window start points and dimensions
        setSize(780,400);
        // close the window when told to
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setResizable(true); // should this window be resizable?
        
        // It'll be nice to have our own logo (feel free to use yours)
        logo = new ImageIcon(getClass().getResource("studyingPays.png"));
        this.setIconImage(logo.getImage());
        
        face = this.getContentPane();
        // background colour - may not be necessay since our canvas will have a colour of its own
        face.setBackground(Color.PINK);

        
        canvas = new CanvasFeel();
        // using the default layout manager
        face.add(canvas, BorderLayout.NORTH);
    }
}