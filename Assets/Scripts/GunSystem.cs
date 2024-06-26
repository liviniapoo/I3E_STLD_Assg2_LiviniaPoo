using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GunSystem : MonoBehaviour
{
   /* ///<summary>
    ///Gun statistics - numbers
    /// </summary>

    public int damage;
    public float timeBtwnShoot, range, reloadTime, timeBtwnShot;
    public int magSize, bulletPT;
    public bool allowHold;
    int ammoLeft, bulletsShot;

    ///<summary>
    ///Gun statistics - booleans
    /// </summary>
    bool shooting, ready, reloading;

    ///<summary>
    ///References
    /// </summary>
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatEnemy;

    private void onFire()
    {
        if (ready && shooting && !reloading && ammoLeft > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        ready = false;

        //Raycast
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<EnemyTakeDamage>().TakeDamage(damage);
            }
        }

        ammoLeft--;
        Invoke("ResetShot", timeBtwnShoot);
    }

    private void ResetShot()
    {
        ready = true;
    }

    private void onReload()
    {
        if (ammoLeft < magSize && !reloading)
        {
            Reload();
        }

    }
   
    private void Reload();
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        ammoLeft = magSize;
        reloading = false;
    }
    private void Awake()
    {
        ammoLeft = magSize;
        readyToShoot = true;
    }*/
}
