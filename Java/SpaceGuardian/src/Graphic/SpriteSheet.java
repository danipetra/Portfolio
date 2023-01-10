/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Graphic;


import java.awt.Image;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import javax.imageio.ImageIO;

/**
 *
 * @author Daniele
 */
public class SpriteSheet {
    private BufferedImage image;
    //construttor
    
    public SpriteSheet(BufferedImage Nimage){
        this.image=Nimage;
    }  

   public BufferedImage    grabImage(int col,   int row, int widht, int height) throws IOException{
    BufferedImage img;
                           
    img = image.getSubimage((col*64)-64,  (row*64)-64, widht, height);
    return img;   
    
    } 
      
}