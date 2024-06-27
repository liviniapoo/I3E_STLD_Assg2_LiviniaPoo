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
    [SerializeField]
    GameObject LootDropped;

    public override void Die()
    {
        base.Die();
        DropLoot();
    }

    void DropLoot()
    {
        Instantiate(LootDropped, transform.position, LootDropped.transform.rotation);
    }
}
