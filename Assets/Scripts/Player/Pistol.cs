using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private Sprite AR_sprite;
    [SerializeField] private GameObject bullet_projectile;
    [SerializeField] private float reload;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float magazine;
    [SerializeField] private bool isReloading;
    [SerializeField] private int maxMagazine;
    [SerializeField] private bool shotCooldownEnded = true;
    [SerializeField] private float fireRate;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.R) && magazine != maxMagazine && isReloading == false) || magazine == 0 && isReloading == false)
            StartCoroutine(Reload());

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (magazine == 0)
        {
            StartCoroutine(Reload());
            
        }

        if (Input.GetMouseButton(0) && magazine > 0 && shotCooldownEnded == true)
        {
            GameObject bullet = Instantiate(bullet_projectile, shotPoint.position, transform.rotation);
            bullet.transform.Rotate(Vector3.forward);
            bullet.transform.gameObject.tag = "PlayerProjectile";
            StartCoroutine(ShotCooldown());
            magazine--;
        }
    }

    IEnumerator Reload() 
    { 
        isReloading = true;
        yield return new WaitForSeconds(5f);
        if (isReloading)
            magazine = maxMagazine;
        isReloading = false; 
    }

    IEnumerator ShotCooldown()
    {
        shotCooldownEnded = false;
        yield return new WaitForSeconds(1 / fireRate);
        shotCooldownEnded = true;
    }
}
