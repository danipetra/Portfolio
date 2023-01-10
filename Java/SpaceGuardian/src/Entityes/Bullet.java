/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Entityes;

import Entityes.Interfaces.FriendlyEntity;
import Graphic.Sprite;
import Logic.Controller;
import Main.GamePanel;
import java.awt.Graphics;
import java.awt.Rectangle;
import java.io.IOException;

/**
 *
 * @author Daniele
 */
public class Bullet extends GameObject implements FriendlyEntity {
    

    public Bullet(int x, int y, Sprite sprite,GamePanel gamePanel, Controller controller) throws IOException {
        super(x, y, sprite, gamePanel, controller);
 }
    

    public void update() {
        //velocità del proiettile
        y = y - 10;
        
    }

    public void render(Graphics g) {
        g.drawImage(sprite.bullet,  x,  y, null);
    }

    //da cambiare in base alle dim della sprite
    public Rectangle getBounds() {
        return new Rectangle( x,  y, 64, 64);
    }

   
    

}
