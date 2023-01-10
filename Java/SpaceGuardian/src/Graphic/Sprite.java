/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Graphic;


import Main.GamePanel;
import java.awt.image.BufferedImage;
import java.io.IOException;

/**
 *
 * @author Daniele
 */
public class Sprite {

    public BufferedImage player, bullet, enemy, asteroid,   alien;
    private SpriteSheet ss;

    public Sprite(GamePanel gamePanel) throws IOException  {
        //per fare il return nella classe game
        ss = new SpriteSheet(gamePanel.getSpriteSheet());
        getTextures();

    }

    private void getTextures() throws IOException  {
        
        player = ss.grabImage(1, 2, 64, 64);
        bullet = ss.grabImage(2, 1, 64, 64);
        enemy = ss.grabImage(3, 2, 64, 64);
        asteroid = ss.grabImage(4, 1, 64, 64);//TOCHANGEEEEEEE
        alien = ss.grabImage(5, 1, 64, 64);
    }
}
