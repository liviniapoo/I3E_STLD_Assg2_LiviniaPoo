/*
 * Author: Livinia Poo
 * Date: 28/06/2024
 * Description: 
 * Destroys gemstone asset upon collection using parent class, declares player has special collectible
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGemstone : Collectible
{
    public override void Collect()
    {
        base.Collect();
        Player.gemstoneCollected = true;
    }
}
