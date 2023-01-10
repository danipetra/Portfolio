/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logic;

import Entityes.Player;
import Main.GamePanel;
import java.awt.Rectangle;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

/**
 *
 * @author Daniele
 */
public class MouseInput implements MouseListener {
    
   

 
    public void mouseClicked(MouseEvent e) {
       
    }


    public void mousePressed(MouseEvent e) {
        int mx= e.getX();
        int my= e.getY();
        
    
       //PLAY BUTTON
       if((mx    >   GamePanel.WIDHT  /2  -70 )&&(mx<=   GamePanel.WIDHT/2    +50)){
         if((my    >   400)&&(my<=   450)){
             
            GamePanel.State =   GamePanel.STATE.GAME;
            
         }
       }
       
       //EXIT BUTTON
       if((mx    >   GamePanel.WIDHT  /2  -80)&&(mx<=   GamePanel.WIDHT/2    +30)){
         if((my    >   470)&&(my<=   530)){
             
            
            System.exit(0);
         }
       }
    }


     public void mouseReleased(MouseEvent e) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

  
    public void mouseEntered(MouseEvent e) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }


    public void mouseExited(MouseEvent e) {
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
}
