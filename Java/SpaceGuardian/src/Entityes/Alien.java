/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Entityes;

import Entityes.Interfaces.EnemyEntity;
import Entityes.Interfaces.FriendlyEntity;
import Graphic.Sprite;
import Logic.CollisionsDetector;
import Logic.Controller;
import Main.GamePanel;
import java.awt.Graphics;
import java.awt.Rectangle;
import java.util.Random;

/**
 *
 * @author Daniele
 */
public class Alien extends GameObject implements EnemyEntity {

    public int HEALTH = 1000;
    Random r = new Random();
    private int speedY;
    private int speedX;

    private static final int points = 2000;

    public Alien(int x, int y, Sprite sprite, Controller controller, GamePanel gamePanel) {
        super(x, y, sprite, gamePanel, controller );

        speedY = 5;
        speedY += r.nextInt(10);
        speedX = 3;
        speedX += r.nextInt(3);
         x=  r.nextInt(GamePanel.WIDHT   - 80);
    }

    public void update() {
      

        y += speedY;
        x += speedX;
        
        if (y >= (GamePanel.HEIGHT)) {
            x=  r.nextInt(GamePanel.WIDHT   - 80);
            y = 0;
            
            speedY = 5;
            speedY += r.nextInt(10);
            speedX = 3;
            speedX += r.nextInt(3);
            x = 10;
            y += speedY;
            x += speedX;
        }
        //COLLISIONS 
        //--------->

        for (int i = 0; i < gamePanel.BulletsList.size(); i++) {

            FriendlyEntity TempEnt = gamePanel.BulletsList.get(i);
            if (CollisionsDetector.CollisionVSPlayer(this, TempEnt)) {

                if (HEALTH > 0) {
                    this.HEALTH -= 250;
                    controller.removeBullet(TempEnt);
                } else if (HEALTH == 0) {

                    controller.removeBullet(TempEnt);
                    controller.removeAlien(this);
                    gamePanel.setAliensKilled(gamePanel.getAliensKilled()+ 1);
                    gamePanel.setScore(gamePanel.getScore() + points);
                }

            }

        }
    }

    public void render(Graphics g) {

        g.drawImage(sprite.alien,  x,  y, null);

    }

    //collision's rectangle: dimensions depend to the spritesheet
   public Rectangle getBounds() {
        return new Rectangle( x,  y, 64, 64);
    }

}
