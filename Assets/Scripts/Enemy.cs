using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float followSpeed;
    [SerializeField] private int damage;
    [SerializeField] private Transform bulletHit;
    [SerializeField] private GameObject player;

    //private bool isFlipped = false;
    //private bool isTouchingPlayer = false;  
    //private bool facingRight = true;
    //private bool cooldownEnded = true;
    //private float distance;

    private int randomSpot;
    public Transform[] moveSpots;
    private float waitTime;
    public float startWaitTime;


    private void Start()
    {
        waitTime = startWaitTime;
        randomSpot = UnityEngine.Random.Range(0, moveSpots.Length);
    }
    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, followSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = UnityEngine.Random.Range(0,moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        //if (isTouchingPlayer && cooldownEnded)
        //{        
        //    player.GetComponent<Health>().TakeDamage(damage);
        //    StartCoroutine(Cooldown());          
        //}
    }
    private void FixedUpdate()
    {
    //    if (isTouchingPlayer == false)
    //    {
    //        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
    //    }
              
        //if (player.GetComponent<Transform>().position.x > transform.position.x && isFlipped == false)
        //{
        //    Flip();
        //    isFlipped = true;
        //}
        //else if (player.GetComponent<Transform>().position.x < transform.position.x && isFlipped == true)
        //{
        //    Flip();
        //    isFlipped = false;
        //}

        //////distance = Vector2.Distance(player.transform.position, transform.position);
        //////RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized);
        //////bulletHit.position = hit.point;

    }

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

    //IEnumerator Cooldown()
    //{
    //    cooldownEnded = false;
    //    yield return new WaitForSeconds(1);
    //    cooldownEnded = true;
    //}

    //void Flip()
    //{
    //    facingRight = !facingRight;
    //    Vector3 Scaler = transform.localScale;
    //    Scaler.x *= -1;
    //    transform.localScale = Scaler;
    //}
}