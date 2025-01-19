using Unity.VisualScripting;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] private int _rifleAmmo;
    [SerializeField] private int _pistolAmmo;
    [SerializeField] public int currentRifleAmmo;
    [SerializeField] public int currentPistolammo;
    [SerializeField] public int _machinegunAmmo;
    [SerializeField] public int currentMachinegunAmmo;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<Player>()._ammoCrateIsAvailable)
        {
            Debug.Log("pisyapopa");
            currentRifleAmmo = _rifleAmmo;
            currentPistolammo = _pistolAmmo;
        }
    }
}
