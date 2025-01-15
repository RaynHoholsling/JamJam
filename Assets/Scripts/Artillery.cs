using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Artillery : MonoBehaviour
{
    [SerializeField] GameObject pointUpper1;
    [SerializeField] GameObject pointUpper2;
    [SerializeField] GameObject pointDown1;
    [SerializeField] GameObject Player;
    void Start()
    {
        StartCoroutine(Shelling());
    }
    void ArtilleryShells()
    {
        StartCoroutine(MuzzleFlash());
        Vector2 position = new Vector2(Random.Range(pointUpper1.transform.position.x, pointUpper2.transform.position.x), pointUpper2.transform.position.y);
        transform.position = position;
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, 1);
        if (collider2D.Length > 0)
        {
            foreach (Collider2D col in collider2D)
            {
                if (col.tag == "Player")
                {
                    Destroy(Player);
                }
            }
        }
    }
    IEnumerator Shelling()
    {
        yield return new WaitForSeconds(1);
        
        ArtilleryShells();
        StartCoroutine(Shelling());
    }
    IEnumerator MuzzleFlash()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
