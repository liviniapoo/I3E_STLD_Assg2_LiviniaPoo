/*
 * Author: Livinia Poo
 * Date: 24/06/2024
 * Description: 
 * Controls gun shooting and reloading
 */

using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// Determines gun's statistics
    /// </summary>
    public float gunDamage = 10f;
    public float gunRange = 100f;
    public float fireRate = 15f;

    /// <summary>
    /// Determines the starting state of the gun
    /// </summary>
    public int maxAmmo = 15;
    public static int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    ///<summary>
    /// Referencing Audio Clips for Effects
    /// </summary>
    public AudioSource sfxAudio;

    /// <summary>
    /// Sets the gun to be loaded upon start
    /// </summary>
    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    /// <summary>
    /// Reloads and fires gun every frame if triggered/conditions met
    /// </summary>
    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (isReloading)
            {
                return;
            }

            if (currentAmmo <= 0)
            {
                if (Player.ammoCount > 0)
                {
                    StartCoroutine(Reload());
                    return;
                }
                else
                {
                    Debug.Log("No more ammo");
                }
            }

            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                muzzleFlash.Play();
                sfxAudio.Play();

            }
        }
    }

    /// <summary>
    /// Fires gun upon click and deals damage to enemies
    /// </summary>
    void Shoot()
    {
        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, gunRange))
        {
            Debug.Log(hit.transform.name);
            BossAI boss = hit.transform.GetComponent<BossAI>();
            if (boss != null)
            {
                boss.TakeDamage(gunDamage);
                Debug.Log("Boss Health:  " + boss.bossHealth);
            }

            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(gunDamage);
            }
        }
    }

    /// <summary>
    /// Uses coroutines to automaticallt reload the gun when ammo is out
    /// </summary>
    /// <returns></returns>
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        Player.ammoCount -= 15;
    }
}
