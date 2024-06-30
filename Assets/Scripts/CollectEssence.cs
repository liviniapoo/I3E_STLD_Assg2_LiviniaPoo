/*
 * Author: Livinia Poo
 * Date: 28/06/2024
 * Description: 
 * Destroys essenc asset upon collection using parent class, declares player has crystal essence
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEssence : Collectible
{
    public override void Collect()
    {
        base.Collect();
        Player.essenceCollected = true;
    }
}
