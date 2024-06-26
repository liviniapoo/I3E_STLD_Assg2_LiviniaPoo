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
    bool canDealDamage;
    bool hasDealtDamage;

    [SerializeField]
    float weaponLength;
    [SerializeField]
    float weaponDamage;

    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = false;
    }

    void Update()
    {
        if (canDealDamage && !hasDealtDamage)
        {
            RaycastHit hit;

            int layerMask = 1 << 8;
            if(Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                /*print("Enemy dealt damage");
                hasDealtDamage = true;*/

                if (hit.transform.TryGetComponent(out Player playerHealth))
                {
                    playerHealth.TakeDamage(weaponDamage);
                    hasDealtDamage = true;
                    Debug.Log("playerHealth");
                }
            }
        }
    }

    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage = false;
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
