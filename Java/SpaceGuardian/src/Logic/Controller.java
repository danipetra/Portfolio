/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logic;

import Entityes.Alien;
import Entityes.Asteroid;
import Entityes.Enemy;
import Entityes.Interfaces.FriendlyEntity;
import Entityes.Interfaces.EnemyEntity;
import Graphic.Sprite;
import Main.GamePanel;
import java.awt.Graphics;
import java.util.LinkedList;
import java.util.Random;

/**
 *
 * @author Daniele
 */
public class Controller {

    //lists of the entities in the game
    private LinkedList<FriendlyEntity> BulletsList = new LinkedList<FriendlyEntity>();
    
    private LinkedList<EnemyEntity> EnemyesList = new LinkedList<EnemyEntity>();
    private LinkedList<EnemyEntity> AsteroidsList = new LinkedList<EnemyEntity>();
    private LinkedList<EnemyEntity> AliensList = new LinkedList<EnemyEntity>();
    
    //entities of the lists
    private FriendlyEntity BulletObject;
    private EnemyEntity EnemyObject;
    private EnemyEntity AsteroidObject;
    private EnemyEntity AlienObject;
    
    private Sprite sprite;
    private GamePanel gamePanel;
    Random r = new Random();

    public Controller(Sprite sprite, GamePanel gamePanel) {

        this.sprite = sprite;
        this.gamePanel = gamePanel;
    }

    public void update() {
        //Bullets
        int i;
        for (i = 0; i < BulletsList.size(); i++) {
            BulletObject = BulletsList.get(i);
            BulletObject.update();

        }

        //Enemies
        int k;
        for (k = 0; k < EnemyesList.size(); k++) {
            EnemyObject = EnemyesList.get(k);

            EnemyObject.update();
        }
        
        
        //Asteroids
        int j;
        for (j = 0; j < AsteroidsList.size(); j++) {
            AsteroidObject = AsteroidsList.get(j);
            AsteroidObject.update();

        }
        
        //Aliens
        int l;
        for (l = 0; l < AliensList.size(); l++) {
            AlienObject = AliensList.get(l);
            AlienObject.update();

        }
        
    }

    public void createEnemy(int enemy_count) {

        int i;
        for (i = 0; i < enemy_count; i++) {
            addEnemy(new Enemy(r.nextInt(GamePanel.WIDHT) - 80, 0, sprite, gamePanel, this));
        }
    }

    
    public void createAsteroid(int asteroid_count){
        int i;
        
            for(i=0;    i   <   asteroid_count; i++   ){
                addAsteroid(new Asteroid(r.nextInt(GamePanel.WIDHT) - 80, -20,    sprite, gamePanel, this));
            }
    }
    public void createAlien(int alien_count ){
        int i;
        
            for(i=0;    i   <   alien_count; i++   ){
                addAlien(new Alien(r.nextInt(GamePanel.WIDHT) - 80, -20,    sprite, this, gamePanel));
            }
    }
    
    

    public void render(Graphics g) {
        //Bullets
        int i;
        for (i = 0; i < BulletsList.size(); i++) {
            BulletObject = BulletsList.get(i);
            BulletObject.render(g);

        }

        //Enemies
        int k;
        for (k = 0; k < EnemyesList.size(); k++) {
            EnemyObject = EnemyesList.get(k);
            EnemyObject.render(g);

        }
        //Asteroids
        int j;
        for (j = 0; j < AsteroidsList.size(); j++) {
            AsteroidObject = AsteroidsList.get(j);
            AsteroidObject.render(g);

        }
        //Aliens
        int l;
        for (l = 0; l < AliensList.size(); l++) {
            AlienObject = AliensList.get(l);
            AlienObject.render(g);

        }
        
    }

    //adds an object to the BULLETS list
    public void addBullet(FriendlyEntity block){
        BulletsList.add(block);
        
    }
    //removes an object at the BULLETS list
    public void removeBullet(FriendlyEntity block){
        BulletsList.remove(block);
    }
    
    //adds an object to the ENEMIES list
    public void addEnemy(EnemyEntity block){
        EnemyesList.add(block);
        
    }
    //removes an object at the ENEMIES list
    public void removeEnemy(EnemyEntity block){
        EnemyesList.remove(block);
    }
    
    //adds an object to the ASTEROID list
    public void addAsteroid(EnemyEntity block){
        AsteroidsList.add(block);
        
    }
    //removes an object at the ASTEROID list
    public void removeAsteroid(EnemyEntity block){
        AsteroidsList.remove(block);
    }
    //adds an object to the ALIENS list
    public void addAlien(EnemyEntity block){
        AliensList.add(block);
        
    }
    //removes an object at the ALIENS list
    public void removeAlien(EnemyEntity block){
        AliensList.remove(block);
    }
 
    public LinkedList<FriendlyEntity> getBulletsList() {
        return BulletsList;
    }

    public LinkedList<EnemyEntity> getEnemiesList() {
        return EnemyesList;
    }

    public LinkedList<EnemyEntity> getAsteroidsList() {
        return AsteroidsList;
    }
    public LinkedList<EnemyEntity> getAliensList() {
        return AliensList;
    }
}
