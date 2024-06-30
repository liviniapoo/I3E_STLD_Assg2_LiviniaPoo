/*
 * Author: Livinia Poo
 * Date: 28/06/2024
 * Description: 
 * Script to trigger enemy to drop loot upon death
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootDrop : EnemyAI
{
    /// <summary>
    /// Attaching the wanted asset to be spawned
    /// </summary>
    [SerializeField]
    GameObject LootDropped;

    /// <summary>
    /// Upon enemy's death, calls the DropLoot function
    /// </summary>
    public override void Die()
    {
        base.Die();
        DropLoot();
    }

    /// <summary>
    /// Spawns the asset mesh where the enemy dies
    /// </summary>
    void DropLoot()
    {
        Instantiate(LootDropped, transform.position, LootDropped.transform.rotation);
    }
}
