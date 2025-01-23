using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System;


public class Shell : MonoBehaviour
{
    [SerializeField] private float radiusOfDestruction;
    [SerializeField] public AudioClip[] audioClips;
    public AudioSource sourse;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inside"))
        {
            radiusOfDestruction = 3;
            Debug.Log("Inside");
        }
    }

    private void Start()
    {
        Explosion();
        System.Random rnd = new System.Random();
        sourse.PlayOneShot(audioClips[rnd.Next(audioClips.Length)]);

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


    IEnumerator MuzzleFlash()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
