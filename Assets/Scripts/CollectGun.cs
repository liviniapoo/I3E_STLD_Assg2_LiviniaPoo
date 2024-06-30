/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Destroys gun asset upon collection using parent class, declares player has a gun
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGun : Collectible
{
    public override void Collect()
    {
        base.Collect();
        Player.hasGun = true;
    }
}
