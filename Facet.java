package dymetric;

import java.awt.*;
import javax.swing.*;

/**
 * This class just creates a display window to attach our canvas to.
 */
public class Facet extends JFrame {
    
    public Container face;
    public ButtonandCanvasPanels components;
    public ImageIcon logo;
    
    public Facet() {
        // Give our window a title
        super("A window that will hold a Canvas and Button");
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
        
        
        components = new ButtonandCanvasPanels();
        // using the default layout manager
        face.add(components.button_panel, BorderLayout.NORTH);
        // attach appropriate drawing component
        face.add(components.canvas_panel, BorderLayout.CENTER);
    }
}