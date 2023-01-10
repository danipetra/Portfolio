/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logic;

import Graphic.BufferedImagesLoader;
import Main.GamePanel;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Rectangle;
import java.awt.image.BufferedImage;
import java.io.IOException;



public class Menu {
    
    private BufferedImage MenuBackGround;
    private Rectangle PlayButton =   new Rectangle   (GamePanel.WIDHT /   2-50, 450,100,50);
    //public Rectangle HelpButton =   new Rectangle   (GamePanel.WIDHT /   2-50, 550,100,50);
    private Rectangle ExitButton =   new Rectangle   (GamePanel.WIDHT /   2-50, 600,100,50);
    
    public void render(Graphics g) throws IOException{ 
        BufferedImagesLoader loader = new BufferedImagesLoader();
        MenuBackGround  =   loader.loadImage("/Backgrounds/MenuBackgroundPulsanti.png");
        Graphics2D g2d  =   (Graphics2D) g;
        g.drawImage(MenuBackGround, 0, 0, null);
        //g.drawString("Defend The Earth", (GamePanel.WIDHT    /2)    -300,  300);
        
    }
    
}
