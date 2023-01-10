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


public class Asteroid extends GameObject implements EnemyEntity{
    
    public  int HEALTH = 100;
    Random r=   new Random();
    private float speed;
    private static final int points   =   300;
    
    
    public Asteroid(int x, int y, Sprite sprite, GamePanel gamePanel,  Controller controller) {
        super(x, y, sprite, gamePanel, controller );
        speed =  5;
        speed += r.nextInt(5);
        x=  r.nextInt(GamePanel.WIDHT   - 80);
    }
    
    public void update(){
        
        //sets the speed
        y  += speed;
        
        //draw the enemy up again
        if(y    >=(GamePanel.HEIGHT)){
            
            y=0;
            //reassigns a random position
            speed =  5;
        speed += r.nextInt(5);
            x=  r.nextInt(GamePanel.WIDHT   - 80);
            y  += speed;
        }
        //COLLISIONS 
        //--------->
        
        for (int i=0;   i<  gamePanel.BulletsList.size();    i++){
         
            FriendlyEntity TempEnt = gamePanel.BulletsList.get(i);
            if(CollisionsDetector.CollisionVSPlayer(this, TempEnt)){
                
                if(HEALTH > 0){
                    this.HEALTH-=   50;
                    controller.removeBullet(TempEnt);
                }else if(HEALTH ==0){
                
                controller.removeBullet(TempEnt);
                controller.removeAsteroid(this);
                gamePanel.setAsteroidsDestroyed(gamePanel.getAsteroidsDestroyed()+1);
                gamePanel.setScore(gamePanel.getScore() +points);
                }
                
            }
        
        
        
        }
    }
        
    public void render(Graphics g){
        
        g.drawImage(sprite.asteroid, x, y, null);
        
    }
    //collision's rectangle: dimensions depend to the spritesheet
     public Rectangle getBounds() {
        return new Rectangle( x,  y, 64, 64);
    }


    
}
