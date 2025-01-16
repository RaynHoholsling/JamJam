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
    private float radiusOfDestruction;



    void Start()
    {
        StartCoroutine(Shelling());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Outside")
        {
            radiusOfDestruction = 1.5f;
            Debug.Log("Lox");
        }
        else
        {
            radiusOfDestruction = 3;
            Debug.Log("Lox");
        }
    }
    void ArtilleryShells()
    {
        Collider2D collision = new();
        if (collision.tag == "Outside")
        {
            radiusOfDestruction = 1.5f;
            Debug.Log("Lox");
        }
        else
        {
            radiusOfDestruction = 3;
            Debug.Log("Lox");
        }

        StartCoroutine(MuzzleFlash());
        Vector2 position = new Vector2(Random.Range(pointUpper1.transform.position.x, pointUpper2.transform.position.x), Random.Range(pointUpper1.transform.position.y, pointDown1.transform.position.y));
        transform.position = position;
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, radiusOfDestruction);
        
        if (collider2D.Length > 0)
        {
            foreach (Collider2D col in collider2D)
            {
                if (col.tag == "Player")
                {
                    player.GetComponent<Player>().Die();
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
