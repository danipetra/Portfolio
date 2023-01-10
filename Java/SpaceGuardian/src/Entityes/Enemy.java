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
public class Enemy extends GameObject implements EnemyEntity{

    
    Random r=   new Random();
    private int speed;
    private static final int points   =   150;
    
    public Enemy(int x, int y,    Sprite sprite, GamePanel gamePanel, Controller controller) {
       
        super(x, y, sprite, gamePanel, controller );
        speed =  10;
        speed += r.nextInt(10);
        x=  r.nextInt(GamePanel.WIDHT   - 80);
      
    }
  
    public void update(){
        
        
        y  += speed;
        
        if(y    >=(GamePanel.HEIGHT)){
            y=0;
            speed =  10;
            speed += r.nextInt(10);
            x=  r.nextInt(GamePanel.WIDHT   - 80);
            y  += speed;
        }
        //COLLISIONS 
        //--------->
        
        for (int i=0;   i<  gamePanel.BulletsList.size();    i++){
         
            FriendlyEntity TempEnt = gamePanel.BulletsList.get(i);
            if(CollisionsDetector.CollisionVSPlayer(this, TempEnt)){
                
                
                controller.removeBullet(TempEnt);
                controller.removeEnemy(this);
                gamePanel.setEnemiesKilled(gamePanel.getEnemiesKilled() +1);
                gamePanel.setScore(gamePanel.getScore()   + points );
            }
        
        
        
        }
    }
        
    public void render(Graphics g){
        
        g.drawImage(sprite.enemy, x, y, null);
        
    }
    //rettangoloCollisioni :da cambiare in base alle dim della sprite
        public Rectangle getBounds(){
        return new Rectangle(x,   y, 64,  64);
    }

    
}
