using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float radiusOfDestruction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inside"))
        {
            radiusOfDestruction = 3;
            Debug.Log("Inside");
            Explosion();
        }
    }

    private void Start()
    {
        StartCoroutine(Wait());
    }



    void Explosion()
    {
        if (radiusOfDestruction != 3)
        {
            radiusOfDestruction = 1.5f;
            Debug.Log("Outside");
        }
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, radiusOfDestruction);
        if (collider2D.Length > 0)
        {
            foreach (Collider2D col in collider2D)
            {
                if (col.tag == "Player" && col.GetComponent<Player>().inBlindage == false)
                {
                    col.GetComponent<Player>().Die();
                }
            }
        }

        StartCoroutine(MuzzleFlash());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        Explosion();
    }
    IEnumerator MuzzleFlash()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
