/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Main;

import Entityes.Bullet;
import Entityes.Enemy;
import Entityes.Interfaces.EnemyEntity;
import Entityes.Interfaces.FriendlyEntity;
import Entityes.Player;
import Graphic.BufferedImagesLoader;
import Graphic.Sprite;
import Logic.Controller;
import Logic.GameOverMenu;
import Logic.KeyInput;
import Logic.Menu;
import Logic.MouseInput;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.event.KeyEvent;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.util.LinkedList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JPanel;

/**
 *
 * @author Daniele
 */
public class GamePanel extends JPanel implements Runnable {

    public static int WIDHT = 1200;
    public static int HEIGHT = 900;
    private Thread thread;
    private boolean running = false;

    private Graphics2D g;

    private BufferedImage image;
    private BufferedImage BackGround;
    private BufferedImage spritesheet;
    private Sprite sprite;
    
    private boolean isShoting = false;
    private Player player;
    public Controller controller;
    private Menu GameMenu;
    private GameOverMenu gameOverMenu;
    
    //COUNTERS and score of the Game
    public int score    =   0;
    public int enemiesCounter = 3;
    public int enemiesKilled = 0;
    public int asteroidsCounter =   1;
    public int asteroidsDestroyed   =   0;
    public int aliensCounter = 0;
    public int aliensKilled= 0;
    
    //LINKED LISts of the elements of the game
    public LinkedList<FriendlyEntity> BulletsList;
    public LinkedList<EnemyEntity> EnemiesList;
    public LinkedList<EnemyEntity> AsteroidsList;
    public LinkedList<EnemyEntity> AliensList;
    
    public static enum STATE {
        MENU,
        GAME,
        GAMEOVER,
        EXIT
    };

    public static STATE State   =   STATE.MENU; 
    
    
    //elements to count FPSs and refresh
    private int FPS =40;
    private double averageFPS;
    long startTime;
    long URDTimeMillis;
    long waitTime;
    long totalTime;
    int frameCount;
    int maxframeCount;
    long targetTime;

//CONSTRUTTOR
    public GamePanel() {
        super();
        setPreferredSize(new Dimension(WIDHT, HEIGHT));
        setFocusable(true);
        requestFocus();

    }

    public void addNotify() {
        super.addNotify();
        if (thread == null) {
            thread = new Thread(this);
            thread.start();
        }
    }

    @Override
    public void run() {
        try {
            //INIZIALIZATION
            init();
        } catch (IOException ex) {
            Logger.getLogger(GamePanel.class.getName()).log(Level.SEVERE, null, ex);
        }
        //GAMELOOP
        while (running) {

            startTime = System.nanoTime();//get the current nanoseconds
            //------------------------------>
            //3 MAIN METHODS OF THE GAMELOOP
            Update();
            try {
                Render();
            } catch (IOException ex) {
                Logger.getLogger(GamePanel.class.getName()).log(Level.SEVERE, null, ex);
            }
            
            Draw();
            //------------------------------<
            URDTimeMillis = (System.nanoTime() - startTime) / 1000000;
            waitTime = targetTime - URDTimeMillis;
            try {
                Thread.sleep(waitTime);
            } catch (Exception e) {
            }
            totalTime += System.nanoTime() - startTime;
            frameCount++;

            if (frameCount == maxframeCount) {
                averageFPS = 1000.0 / ((totalTime / frameCount) / 1000000);
                frameCount = 0;
                totalTime = 0;
            }
        }

    }

    private void init() throws IOException {
        running = true;
        totalTime = 0;

        frameCount = 0;
        maxframeCount = 40;

        targetTime = 1000 / FPS;
        this.addMouseListener(new MouseInput());
        addKeyListener(new KeyInput(this));
        image = new BufferedImage(WIDHT, HEIGHT, BufferedImage.TYPE_INT_RGB);
        g = (Graphics2D) image.getGraphics();

        BufferedImagesLoader loader = new BufferedImagesLoader();
        BackGround = loader.loadImage("/Backgrounds/MainBackground.png");
        spritesheet = loader.loadImage("/Spritesheet64Pxs.png");
       
                
        sprite = new Sprite(this);
        
        controller = new Controller(sprite, this);
        player = new Player(550, 600, sprite, this, controller);
        
        //linked lists used in the collisions
        
        BulletsList = controller.getBulletsList();
        EnemiesList = controller.getEnemiesList();
        AsteroidsList = controller.getAsteroidsList();
        AliensList = controller.getAliensList();
        
        controller.createEnemy(enemiesCounter);
        controller.createAsteroid(asteroidsCounter);
        
        
        GameMenu = new Menu();
        gameOverMenu    =   new GameOverMenu();
        

    }

    private void Update() {

        player.update();
        controller.update();
        //GENERATION OF THE ENEMIES
        //Aliens
        if((enemiesCounter >=10)&&(aliensKilled >= aliensCounter )){
            aliensCounter++;
            aliensKilled = 0;
            controller.createAlien(aliensCounter);
                 
        }
        //enemies
        if (enemiesKilled >= enemiesCounter) {
            enemiesCounter += 4;
            enemiesKilled = 0;
            controller.createEnemy(enemiesCounter);
            
        }
        //asteroids
        if(asteroidsDestroyed >=    asteroidsCounter){
            asteroidsCounter+=  2;
            asteroidsDestroyed =0;
            controller.createAsteroid(asteroidsCounter);
        }
        
    }
            
    

    private void Render() throws IOException {
        //DRAWS ON THE SCREEN
        //rendering of the elements of the game
        
        if(State == STATE.GAME){
        g.setColor(Color.black);
        g.fillRect(0, 0, WIDTH, HEIGHT);
        g.drawImage(BackGround, 0, 0, null);

        /*SHOW THE FPS IF NECESSARY
        g.setColor(Color.white);
        g.drawString("FPS:  " + averageFPS, 1000, 30);*/

        player.render(g);
        controller.render(g);
        //HEALTHBAR
            g.setColor(Color.gray);
            g.fillRect(5, 5, 200, 50);
            g.setColor(Color.GREEN);
            g.fillRect(5, 5, player.HEALTH, 50);
            g.setColor(Color.BLACK);
            g.drawRect(5, 5, 200, 50);
            //SCORES    
            Font fnt0 = new Font("century gothic", Font.BOLD, 30);
            g.setFont(fnt0);
            g.setColor(Color.GREEN);
            g.drawString("Score:"   +score, (this.WIDHT) / 2 + 380, 880);
        }
        //rendering of the menu(STARTING POINT)
         if(State == STATE.MENU){
             GameMenu.render(g);
         }
         //rendering of the GAMEOVER MENU
         if(State == STATE.GAMEOVER){
             gameOverMenu.render(g);
            Font ScoresFont = new Font("century gothic", Font.BOLD, 30);
            g.setFont(ScoresFont);
            g.setColor(Color.GREEN);
            g.drawString( ""  +score, (this.WIDHT) / 2 -20 ,  436);
            running = false;
         }
         
         
        

    }

    private void Draw() {
        //Draws and disposes the elements on the gamePanel 
        Graphics g2 = this.getGraphics();
        g2.drawImage(image, 0, 0, null);
        g2.dispose();

    }

    public BufferedImage getSpriteSheet() {
        return spritesheet;

    }

    public void keyPressed(KeyEvent e) throws IOException {
        //sets up the keys of the game
        int key = e.getKeyCode();
        //change the spaceship's speed here
        if (key == KeyEvent.VK_RIGHT) {
            player.setVelX(10);
        } else if (key == KeyEvent.VK_LEFT) {
            player.setVelX(-10);
        } else if (key == KeyEvent.VK_DOWN) {
            player.setVelY(10);
        } else if (key == KeyEvent.VK_UP) {
            player.setVelY(-10);
        } else if (key == KeyEvent.VK_SPACE && !isShoting) {
            isShoting = true;
            controller.addBullet(new Bullet(player.getX(), player.getY(), sprite, this, controller));
        }

    }

    public void keyReleased(KeyEvent e) {
        int key = e.getKeyCode();

        if (key == KeyEvent.VK_RIGHT) {
            player.setVelX(0);
        } else if (key == KeyEvent.VK_LEFT) {
            player.setVelX(0);
        } else if (key == KeyEvent.VK_DOWN) {
            player.setVelY(0);
        } else if (key == KeyEvent.VK_UP) {
            player.setVelY(0);
        } else if (key == KeyEvent.VK_SPACE) {
            isShoting = false;

        }

    }

    //OTHERS game mechanics GETTERS-SETTERS
    public int getEnemiesCounter() {
        return enemiesCounter;
    }

    public int getEnemiesKilled() {
        return enemiesKilled;
    }

    public int getAsteroidsDestroyed() {
        return asteroidsDestroyed;
    }

    public int getAliensKilled() {
        return aliensKilled;
    }
    
    

    public void setEnemiesCounter(int enemiesCounter) {
        this.enemiesCounter = enemiesCounter;
    }

    public void setEnemiesKilled(int enemiesKilled) {
        this.enemiesKilled = enemiesKilled;
    }
    
    public void setAsteroidsDestroyed(int asteroidsDestroyed) {
        this.asteroidsDestroyed = asteroidsDestroyed;
    }

    public void setAliensKilled(int aliensKilled) {
        this.aliensKilled = aliensKilled;
    }

    
    public int getScore() {
        return score;
    }

    public void setScore(int score) {
        this.score = score;
    }
}
