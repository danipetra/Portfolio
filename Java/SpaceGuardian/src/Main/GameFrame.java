/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Main;

import javax.swing.JFrame;

/**
 *
 * @author Daniele
 */
public class GameFrame extends JFrame {
    private static String name = "Space Guardian";

    public GameFrame() {
        
        this.setDefaultCloseOperation(GameFrame.EXIT_ON_CLOSE);
        this.setLayout(null);
        this.setContentPane(new GamePanel());
        this.pack();
        this.setResizable(false);
        this.setLocationRelativeTo(null);
        this.setTitle(name);
    }
}
