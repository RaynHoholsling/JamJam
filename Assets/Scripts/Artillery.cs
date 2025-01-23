using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Artillery : MonoBehaviour
{
    [SerializeField] GameObject pointUpper1;
    [SerializeField] GameObject pointUpper2;
    [SerializeField] GameObject pointDown1;
    [SerializeField] GameObject player;
    [SerializeField] GameObject shell;
    [SerializeField] public float radiusOfDestruction;
    [SerializeField] private AudioSource artilleryOut;

    void Start()
    {
        StartCoroutine(Shelling());
    }

    void ArtilleryShells()
    {      
        Vector3 newPosition = new Vector3(Random.Range(pointUpper1.transform.position.x, pointUpper2.transform.position.x), Random.Range(pointUpper1.transform.position.y, pointDown1.transform.position.y), 1);
        GameObject pellet = Instantiate(shell, newPosition, transform.rotation);       
    }
    IEnumerator Shelling()
    {
        artilleryOut.Play();
        yield return new WaitForSeconds(5f);
        
        ArtilleryShells();
        StartCoroutine(Shelling());
    }
    
}
