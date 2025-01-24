using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMachinegunController : MonoBehaviour
{
    [SerializeField] private GameObject machinegun;
    [SerializeField] private GameObject weaponControle;
    [SerializeField] private GameObject cam;
    private bool machinegunEnabled;
    private Player player;
    

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && player.machinegunNear == true)
        {
            player.machinegunNear = false;
            weaponControle.SetActive(false);
            machinegun.GetComponent<MachineGun>().enabled = true;
            machinegunEnabled = true;
            player.GetComponent<Player>().enabled = false;
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 5, cam.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.E) && machinegunEnabled == true)
        {
            player.machinegunNear = true;
            player.GetComponent<Player>().enabled = true;
            weaponControle.SetActive(true);
            machinegun.GetComponent<MachineGun>().enabled = false;
            machinegunEnabled = false;
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 5, cam.transform.position.z);
        }
    }
}
