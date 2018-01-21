package dymetric;

import java.awt.event.*;
import java.awt.*;
import javax.swing.*;

public class ButtonandCanvasPanels implements ActionListener {
    public JPanel button_panel, canvas_panel;
    public JButton motion_bttn;
    public StraightLine motion;
    
    public ButtonandCanvasPanels() {
        button_panel = new JPanel();
        // pick a background colour
        button_panel.setBackground(Color.PINK);
        button_panel.setLayout(new FlowLayout(FlowLayout.CENTER, 0, 0));
        // O my; but for convenience sake let's add our control button here
        motion_bttn = new JButton("Move");
        motion_bttn.setBackground(new Color(255, 0, 255));
        motion_bttn.addActionListener(this);
        // using the default layout manager
        button_panel.add(motion_bttn);
        
        
        canvas_panel = new JPanel();
        canvas_panel.setLayout(new BorderLayout());
        motion = new StraightLine();
        // attach appropriate drawing component
        canvas_panel.add(motion, BorderLayout.CENTER);
    }
    
    /**
     * Respond to the button click event 
     */
    public void actionPerformed(ActionEvent evt) {
        motion.moveInLine();
    }
}