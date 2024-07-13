using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float followSpeed;
    [SerializeField] private int damage;
    [SerializeField] private Transform bulletHit;
    [SerializeField] private GameObject player;

    private bool isFlipped = false; 
    private bool facingRight = false;

    private Transform nextSpot;
    public Transform[] moveSpots;
    private float waitTime;
    public float startWaitTime;
    private bool warning = false;
    int i = 0;


    private void Start()
    {
        waitTime = startWaitTime;
        nextSpot = moveSpots[0];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
      
        transform.position = Vector2.MoveTowards(transform.position, nextSpot.position, followSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, nextSpot.position) < 0.2f)
        {           
            if (waitTime <= 0)
            {
                nextSpot = moveSpots[i];
                if(transform.position.x < nextSpot.GetComponent<Transform>().position.x && isFlipped == false)
                {
                    Flip();
                    isFlipped = true;
                }
                else if(transform.position.x > nextSpot.GetComponent<Transform>().position.x && isFlipped == true)
                {
                    Flip();
                    isFlipped = false;
                }

                if (i == moveSpots.Length - 1)
                {
                    i --;
                }
                else
                {
                    i++;
                }
                waitTime = startWaitTime;
            }
            else
            {              
                waitTime -= Time.deltaTime;
            }
        }
    }
    //private void FixedUpdate()
    //{
    ////    if (isTouchingPlayer == false)
    ////    {
    ////        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
    ////    }
              
    //    //if (player.GetComponent<Transform>().position.x > transform.position.x && isFlipped == false)
    //    //{
    //    //    Flip();
    //    //    isFlipped = true;
    //    //}
    //    //else if (player.GetComponent<Transform>().position.x < transform.position.x && isFlipped == true)
    //    //{
    //    //    Flip();
    //    //    isFlipped = false;
    //    //}

    //    //////distance = Vector2.Distance(player.transform.position, transform.position);
    //    //////RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized);
    //    //////bulletHit.position = hit.point;

    //}

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        isTouchingPlayer = true;
    //    }
    //}

    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        isTouchingPlayer = false;
    //    }
    //}


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}