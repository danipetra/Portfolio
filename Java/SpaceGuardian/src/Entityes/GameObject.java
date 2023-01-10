/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Entityes;

import Graphic.Sprite;
import Logic.Controller;
import Main.GamePanel;
import java.awt.Rectangle;

/**
 *
 * @author Daniele
 */
public class GameObject {
    
    protected int x,    y;
    protected Sprite sprite;
    protected GamePanel gamePanel;
    protected Controller controller;
    
    public GameObject(int x, int y, Sprite sprite, GamePanel gamePanel,Controller controller) {
        this.x = x;
        this.y = y;
        
        this.sprite = sprite;
        this.gamePanel = gamePanel;
        this.controller = controller;
        
    }

    public int getX() {
        return x;
    }

    public int getY() {
        return y;
    }
    
    public void setX(int x) {
        this.x = x;
    }

    public void setY(int y) {
        this.y = y;
    }
    
    
}