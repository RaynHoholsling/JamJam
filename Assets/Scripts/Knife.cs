using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Knife : MonoBehaviour
{
    private bool isTouchingEnemy = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouchingEnemy = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingEnemy = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isTouchingEnemy == true)
        {
            //GameObject obj = GameObject.FindGameObjectWithTag("Enemy");
            Destroy(gameObject);
        }
    }
}
