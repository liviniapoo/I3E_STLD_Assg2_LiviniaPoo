/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Determines player's starting max health
    /// </summary>
    [SerializeField]
    public float playerHealth = 100;
    public float playerMaxHealth = 100;
    public bool isDead = false;

    public PlayerHealthBar healthBar;
    public PlayerDeath deathUI;

    /// <summary>
    /// Referencing door to Normal Door script
    /// </summary>
    private NormalDoor normalDoor;

    /// <summary>
    /// Function to check door in front of player
    /// </summary>
    /// <param name="doorPos"></param>
    public void DoorUpdate(NormalDoor doorPos)
    {
        normalDoor = doorPos;
    }

    /// <summary>
    /// Variables to check whether player has a gun
    /// </summary>
    public static bool hasGun = false;
    /// <summary>
    /// Attaching gun to player
    /// </summary>
    public GameObject gunOnPlayer;

    /// <summary>
    /// Variables to check how much ammo player has
    /// </summary>
    public static int ammoBoxCount = 0;
    public static int ammoCount = 0;

    /// <summary>
    /// Variable to check how many medkits player has
    /// </summary>
    public static int medkitCount = 0;
    /// <summary>
    /// Determines how much health is gained upon using medkit
    /// </summary>
    public int healthRestoredPerHeal = 20;

    /// <summary>
    /// Variable to check how many gears player has
    /// </summary>
    public static int gearCount = 0;

    /// <summary>
    /// Declares that player starts without gemstone
    /// </summary>
    public static bool gemstoneCollected = false;

    /// <summary>
    /// Declares that player starts without crystal essence
    /// </summary>
    public static bool essenceCollected = false;
    public static int essenceCount = 0;

    private void OnHeal()
    {
        if (playerHealth < 100 && medkitCount > 0)
        {
            playerHealth += healthRestoredPerHeal;
            medkitCount -= 1;
            Debug.Log(playerHealth);
            healthBar.SetPlayerHealth(playerHealth);
        }
        else if (medkitCount == 0)
        {
            Debug.Log("No more medkits!");
        }
    }

    /// <summary>
    /// Allows player to take damage when attacked by enemies, die when health is 0
    /// </summary>
    /// <param name="damageAmt"></param>
    public void TakeDamage(float damageAmt)
    {
        playerHealth -= damageAmt;
        healthBar.SetPlayerHealth(playerHealth);

        if (playerHealth <= 0 && !isDead)
        {
            isDead = true;
            deathUI.playerDeathUI.SetActive(true);
            Die();
        }
    }

    /// <summary>
    /// Destroys player object upon death
    /// </summary>
    void Die()
    {
        Debug.Log("Player died");
    }

    /// <summary>
    /// Disables gun on player on start
    /// </summary>
    private void Start()
    {
        gunOnPlayer.SetActive(false);
        healthBar.SetPlayerMaxHealth(playerMaxHealth);
        deathUI.playerDeathUI.SetActive(false);
    }

    /// <summary>
    /// Enables gun on player once they collect a gun
    /// </summary>
    private void Update()
    {
        if(hasGun)
        {
            gunOnPlayer.SetActive(true);
        }
    }
}
