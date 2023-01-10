/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logic;

import Main.GamePanel;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;


public class KeyInput extends KeyAdapter{
    private GamePanel gamePanel;
    
    public KeyInput (GamePanel gamePanel){
        this.gamePanel   =  gamePanel;
        
    }
    
    public void keyPressed(KeyEvent e){
        try {
            gamePanel.keyPressed(e);
        } catch (IOException ex) {
            Logger.getLogger(KeyInput.class.getName()).log(Level.SEVERE, null, ex);
        }
        
    }
    public void keyReleased(KeyEvent e){
        gamePanel.keyReleased(e);
    }
}
