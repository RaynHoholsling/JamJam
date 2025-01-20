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
    [SerializeField] private GameObject Player;
    Animator animator;
    private bool isFlipped = false; 
    private bool facingRight = true;


    private Transform nextSpot;
    public Transform[] moveSpots;
    [SerializeField]  private float waitTime;
    public float startWaitTime;
    [SerializeField] private bool isGoingBack;
    [SerializeField] private float _rayCastDistance;
    [SerializeField] private bool _playerSpotted;
    [SerializeField] private bool _isInvestigating;
    [SerializeField] private bool _isSeeingPlayer;
    [SerializeField] private Sprite deadSprite;
    [SerializeField] private GameObject _deadBody;
    [SerializeField] private GameObject _rayObject;
    private int _rayScaler = 1;
    int i = 0;


    private void Start()
    {
        waitTime = startWaitTime;
        nextSpot = moveSpots[0];
        if (transform.position.x < nextSpot.GetComponent<Transform>().position.x && isFlipped == true)
        {
            Flip();
            isFlipped = false;
        }
        else if (transform.position.x > nextSpot.GetComponent<Transform>().position.x && isFlipped == false)
        {
            Flip();
            isFlipped = true;
        }
        animator = GetComponent<Animator>();
    }



    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {

//    } 
//}       FOR RAYCAST 

private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playerSpotted = false;
        }
    }
    public void Die()
    {
        Instantiate(_deadBody, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (animator)
        {
            animator.SetBool("Run", Mathf.Abs(waitTime) >= startWaitTime);
        }
      
        transform.position = Vector2.MoveTowards(transform.position, nextSpot.position, followSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, nextSpot.position) < 0.2f)
        {           
            if (waitTime <= 0)
            {
                nextSpot = moveSpots[i];
                if(transform.position.x < nextSpot.GetComponent<Transform>().position.x && isFlipped == true)
                {
                    Flip();
                    isFlipped = false;
                }
                else if(transform.position.x > nextSpot.GetComponent<Transform>().position.x && isFlipped == false)
                {
                    Flip();
                    isFlipped = true;
                }

                if (i == moveSpots.Length - 1 || isGoingBack == true )
                {
                    i --;
                    isGoingBack = true;
                    if (i == 0)
                    {
                        isGoingBack = false;
                    }                   
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

    private void FixedUpdate()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(_rayObject.transform.position, Vector2.right * _rayScaler);
        RaycastHit2D hitPlayerUp = Physics2D.Raycast(_rayObject.transform.position, _rayScaler * 0.5f * Vector2.up);
        RaycastHit2D hitPlayerDown = Physics2D.Raycast(_rayObject.transform.position, Vector2.down * _rayScaler * 0.5f);
        Debug.DrawRay(_rayObject.transform.position, Vector2.right * _rayCastDistance * _rayScaler, Color.red);
        Debug.DrawRay(_rayObject.transform.position, Vector2.up * _rayCastDistance * _rayScaler * 0.5f, Color.red);
        Debug.DrawRay(_rayObject.transform.position, Vector2.down * _rayCastDistance * _rayScaler * 0.5f, Color.red);

        if (hitPlayer.collider.tag == "Player" || hitPlayerUp.collider.tag == "Player" || hitPlayerDown.collider.tag == "Player")
        {
            Debug.Log("fdfdfsdf");
            _playerSpotted = true;
            if (_isInvestigating == false)
            {
                StartCoroutine(Investigating());
            }
            if (_isSeeingPlayer == false)
            {
                StartCoroutine(SeeingPlayer());
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        _rayScaler *= -1;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    
   

    IEnumerator SeeingPlayer()
    {
        Debug.Log("Player spotted");
        _isSeeingPlayer = true;
        yield return new WaitForSeconds(1);

        if (_playerSpotted)
        {
           
            Debug.Log("Player killed");
        }

        _isSeeingPlayer = false;
    }
    IEnumerator Investigating()
    {
        _isInvestigating = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        followSpeed = 0;
       
        yield return new WaitForSeconds(5);

        _isInvestigating = false;
        followSpeed = 2;
     
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}