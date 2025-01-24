using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MachineGun : MonoBehaviour
{
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float reloadStart;
    [SerializeField] private int magazineSizeStart;
    [SerializeField] private float fireRate;
    [SerializeField] private float magazineSize;
    [SerializeField] private AudioSource _shotSound;

    public bool shotCooldownEnded = true;
    [SerializeField] private bool _isInBattle = false;
    private bool isLoading = false;
    public bool cartridgeLoaded = true;
    [SerializeField] private bool reloadStarted = false;

    private void Start()
    {
        magazineSize = magazineSizeStart;
    }
    
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.R) && magazineSize != magazineSizeStart) || magazineSize == 0)
            reloadStarted = true;

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (difference.y < 2)
        {
            difference.y = 2;
        }
        
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        projectile.transform.rotation = transform.rotation;

        if (Input.GetMouseButton(0) && magazineSize > 0 && shotCooldownEnded == true)
        {           
            _shotSound.Play();
            reloadStarted = false;
            isLoading = false;
            StopCoroutine(LoadCartridge());
            StartCoroutine(MuzzleFlash());
            StartCoroutine(ShotCooldown());
            GameObject pellet = Instantiate(projectile, shotPoint.position, transform.rotation);
            magazineSize--;
        }

        else if (reloadStarted == true && cartridgeLoaded == true && magazineSize < magazineSizeStart)
        {
            isLoading = true;
            StartCoroutine(LoadCartridge());
        }
    }

    IEnumerator MuzzleFlash()
    {
        shotPoint.GetComponent<SpriteRenderer>().enabled = true;
        shotPoint.GetComponent<Light2D>().enabled = true;
        yield return new WaitForSeconds(0.08f);
        shotPoint.GetComponent<SpriteRenderer>().enabled = false;
        shotPoint.GetComponent<Light2D>().enabled = false;
    }

    IEnumerator ShotCooldown()
    {
        shotCooldownEnded = false;
        yield return new WaitForSeconds(1 / fireRate);
        shotCooldownEnded = true;
    }

    IEnumerator LoadCartridge()
    {
        cartridgeLoaded = false;
        yield return new WaitForSeconds(4);
        if (isLoading)
        {
            magazineSize = 100;
        }                   
        cartridgeLoaded = true;
    }
}

