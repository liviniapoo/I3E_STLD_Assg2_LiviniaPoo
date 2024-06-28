/*
 * Author: Livinia Poo
 * Date: 27/06/2024
 * Description: 
 * Destroys gear asset upon collection using parent class, increases gear count
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGearPart : Collectible
{
    public override void Collect()
    {
        base.Collect();
        Player.gearCount++;
    }
}
