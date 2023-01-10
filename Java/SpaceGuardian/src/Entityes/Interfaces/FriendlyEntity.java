/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Entityes.Interfaces;

import java.awt.Graphics;
import java.awt.Rectangle;


public interface FriendlyEntity {
    
    public void update();
    public void render(Graphics g);
    public Rectangle getBounds();
    
    
    
}
