using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int selectedWeapon = 0;
    public Kar98 kar98;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        //if (collision.tag == "PLayer" && Input.GetKeyDown(KeyCode.E))
        //{

        //}

        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }          
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0; 
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                if (kar98 != null)
                {
                    kar98.shotCooldownEnded = true;
                    kar98.cartridgeLoaded = true;
                }
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
