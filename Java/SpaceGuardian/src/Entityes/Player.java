/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Entityes;

import Entityes.Interfaces.FriendlyEntity;
import Entityes.GameObject;
import Entityes.Interfaces.EnemyEntity;
import Graphic.Sprite;
import Logic.CollisionsDetector;
import Logic.Controller;
import Main.GamePanel;

import java.awt.Graphics;
import java.awt.Rectangle;
import java.awt.image.BufferedImage;
import java.io.IOException;




public  class Player extends GameObject implements FriendlyEntity{
  
    private double velX=0;
    private double velY=0;

    public int HEALTH   =   200;
    private final static int points   =   100;
  
    
    
    public Player(int x, int y, Sprite NSprite, GamePanel gamePanel, Controller controller ) throws IOException {
        
        super(x, y, NSprite, gamePanel, controller );
       
    }
    
    public void update(){
               
        
        x+=velX;
        y+=velY;
        //window collisions
        if(x    <=0)
            x=0;
        
        if(x    >=1200-64)
            x=1200   -64;
        
        if(y    <=0)
            y=0;
        
        if(y    >=900-64)
            y=900-64;
        //COLLISIONS WITH ENEMYES
        //------------------------------>
        for(int i=0;    i<  gamePanel.EnemiesList.size();    i++){
        
            EnemyEntity TemporaryEnemy=   gamePanel.EnemiesList.get(i);
            
            
            if(CollisionsDetector.CollisionVSEnemy(this,  TemporaryEnemy)){
                
                 controller.removeEnemy(TemporaryEnemy);//it removes the enemy spaceship
                gamePanel.setEnemiesKilled(gamePanel.getEnemiesKilled() +1);
                gamePanel.setScore(gamePanel.getScore()   + points );
                this.HEALTH =   this.HEALTH-20;
                if(this.HEALTH  <=  0){
                    GamePanel.State = GamePanel.STATE.GAMEOVER;
                }
                
            }
        }
        //COLLISIONS WITH ASTEROIDS
        //------------------------>
        for(int k=0;    k<  gamePanel.AsteroidsList.size();    k++){
        
            EnemyEntity TemporaryAsteroid=   gamePanel.AsteroidsList.get(k);
            
            
            if(CollisionsDetector.CollisionVSEnemy(this,  TemporaryAsteroid)){
                
                controller.removeAsteroid(TemporaryAsteroid);//it removes the enemy spaceship
                gamePanel.setAsteroidsDestroyed(gamePanel.getAsteroidsDestroyed()   +1);
                gamePanel.setScore(gamePanel.getScore()   + points );
                this.HEALTH =   this.HEALTH-50;
                if(this.HEALTH  <=  0){
                    GamePanel.State = GamePanel.STATE.GAMEOVER;
                }
                
            }
        }
        
        //COLLISIONS WITH ALIENS
        //------------------------>
        for(int l=0;    l<  gamePanel.AliensList.size();    l++){
        
            EnemyEntity TemporaryAlien=   gamePanel.AliensList.get(l);
            
            
            if(CollisionsDetector.CollisionVSEnemy(this,  TemporaryAlien)){
                
                controller.removeAlien(TemporaryAlien);//it removes the enemy spaceship
                gamePanel.setAliensKilled(gamePanel.getAliensKilled()+1);
                gamePanel.setScore(gamePanel.getScore()   + points );
                this.HEALTH =   this.HEALTH-30;
                if(this.HEALTH  <=  0){
                    GamePanel.State = GamePanel.STATE.GAMEOVER;
                }
                
            }
        }
        
           
    }
    public void render(Graphics g){
        g.drawImage(sprite.player,(int) x,(int) y,   null);
        
    }

    public void setVelX(double velX) {
        this.velX = velX;
    }

    public void setVelY(double velY) {
        this.velY = velY;
    }

    

    
    //da cambiare in base alle dim della sprite
        public Rectangle getBounds(){
        return new Rectangle(x,  y, 64, 64);
    }


    
    
}
