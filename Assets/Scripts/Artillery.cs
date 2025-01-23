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
    [SerializeField] private AudioSource artilleryFall1;
    [SerializeField] private AudioSource artilleryFall2;
    [SerializeField] private AudioSource artilleryFall3;



    void Start()
    {
        StartCoroutine(Shelling());
    }

    void Randome()
    {
        int rnd = Random.Range(1, 3);
        if (rnd == 1)
        {
            artilleryFall1.Play();
        }
        else if (rnd == 2)
        {
            artilleryFall2.Play();
        }
        else if (rnd == 3)
        {
            artilleryFall3.Play();
        }
    }


    void ArtilleryShells()
    {

        
        Randome();
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
