using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbedwire : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Die();
        }
        else if (collision.gameObject.CompareTag("EnemyInWave"))
        {
            collision.gameObject.GetComponent<EnemyInWave>().Die();
        }
    }
}
