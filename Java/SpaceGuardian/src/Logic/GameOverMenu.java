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


public class GameOverMenu {
    private BufferedImage GameOverMenuBackGround;
    private Rectangle RePlayButton =   new Rectangle   (GamePanel.WIDHT /   2-50, 450,100,50);
    private Rectangle ExitButton   =   new Rectangle   (GamePanel.WIDHT /   2-50, 600,100,50);
    
    
    
    
    public void render(Graphics g) throws IOException{
        Graphics2D g2d  =   (Graphics2D) g;
        BufferedImagesLoader loader = new BufferedImagesLoader();
        GameOverMenuBackGround =   loader.loadImage("/Backgrounds/GameOverBackgroundWITHOUTNEWGAME.png");
        g.drawImage(GameOverMenuBackGround, 0, 0, null);
        
        
       
       
    }
    
}
