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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        radiusOfDestruction = 1.5f;
        Debug.Log("Outside");
        Explosion();
    }


    void Explosion()
    {
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


    IEnumerator MuzzleFlash()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
