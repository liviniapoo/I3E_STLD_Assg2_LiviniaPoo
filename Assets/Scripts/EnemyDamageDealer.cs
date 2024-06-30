/*
 * Author: Livinia Poo
 * Date: 26/06/2024
 * Description: 
 * Allowing enemies to deal damage to Player during attacks
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    /// <summary>
    /// For determining the state of the weapon's damage ability
    /// </summary>
    bool canDealDamage;
    bool hasDealtDamage;

    /// <summary>
    /// Variables to determine weapon's statistics
    /// </summary>
    [SerializeField]
    float weaponLength;
    [SerializeField]
    float weaponDamage;

    /// <summary>
    /// Sets weapon's abilities to do nothing
    /// </summary>
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = false;
    }

    /// <summary>
    /// Uses raycast to determine whether player is hit by weapon, and removes health accordingly
    /// </summary>
    void Update()
    {
        if (canDealDamage && !hasDealtDamage)
        {
            RaycastHit hit;

            int layerMask = 1 << 8;
            if(Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                if (hit.transform.TryGetComponent(out Player playerHealth))
                {
                    playerHealth.TakeDamage(weaponDamage);
                    hasDealtDamage = true;
                }
            }
        }
    }

    /// <summary>
    /// Declares that damage is being dealt
    /// </summary>
    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage = false;
    }

    /// <summary>
    /// Declares that damage is no longer being dealt
    /// </summary>
    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    /// <summary>
    /// Highlights where the damage is being detected
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
