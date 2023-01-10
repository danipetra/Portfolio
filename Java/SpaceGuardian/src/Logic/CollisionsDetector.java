/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logic;

import Entityes.Interfaces.EnemyEntity;
import Entityes.Interfaces.FriendlyEntity;

/**
 *
 * @author Daniele
 */
public class CollisionsDetector {
    
    
public static boolean CollisionVSEnemy(FriendlyEntity enta, EnemyEntity entb){
        
        if(enta.getBounds().intersects(entb.getBounds())){
                return true;
            
        }
        return false;
}

    public static boolean CollisionVSPlayer(EnemyEntity entb, FriendlyEntity enta){
        
          if(entb.getBounds().intersects(enta.getBounds())){
                return true;
            
        }
        return false;
    }
    
    
    
}
