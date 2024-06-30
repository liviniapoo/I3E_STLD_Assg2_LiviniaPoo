
using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float gunDamage = 10f;
    public float gunRange = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 15;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
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
            
        }
    }

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

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
