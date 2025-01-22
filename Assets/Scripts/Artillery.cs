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



    void Start()
    {
        StartCoroutine(Shelling());
    }

    //void ArtilleryRadius()
    //{
    //    Vector2 position = new Vector2(Random.Range(pointUpper1.transform.position.x, pointUpper2.transform.position.x), Random.Range(pointUpper1.transform.position.y, pointDown1.transform.position.y));
    //    transform.position = position;
    //    Collider2D[] collision = Physics2D.OverlapCircleAll(transform.position, 0.1f);
    //}


    void ArtilleryShells()
    {
        Vector3 newPosition = new Vector3(Random.Range(pointUpper1.transform.position.x, pointUpper2.transform.position.x), Random.Range(pointUpper1.transform.position.y, pointDown1.transform.position.y), 1);
        GameObject pellet = Instantiate(shell, newPosition, transform.rotation);       
    }
    IEnumerator Shelling()
    {
        yield return new WaitForSeconds(2.5f);
        
        ArtilleryShells();
        StartCoroutine(Shelling());
    }
    
}
