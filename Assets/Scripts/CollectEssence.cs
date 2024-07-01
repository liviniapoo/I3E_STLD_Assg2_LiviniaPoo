/*
 * Author: Livinia Poo
 * Date: 28/06/2024
 * Description: 
 * Destroys essence asset upon collection using parent class, declares player has crystal essence
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEssence : Collectible
{
    /// <summary>
    /// Collects using parent script, references GameManager to activate tele
    /// </summary>
    public override void Collect()
    {
        base.Collect();
        Player.essenceCollected = true;
        Player.essenceCount = 1;
        
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateTeleMesh();
        }
    }
}
