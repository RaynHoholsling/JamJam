using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class EnemyStatic : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float followSpeed;
    [SerializeField] private GameObject Player;
    Animator animator;
    private bool isFlipped = false;
    private bool facingRight = true;
    [SerializeField] private Sprite _deadSprite;

    private Transform nextSpot;
    public Transform[] moveSpots;
    [SerializeField]  private float waitTime;
    public float startWaitTime;
    [SerializeField] private bool _playerSpotted;
    [SerializeField] private bool _isInvestigating;
    [SerializeField] private bool _isSeeingPlayer;
    int i = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playerSpotted = false;
        }
    }
    public virtual void Die()
    {
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        GetComponent<EnemyStatic>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
        

    IEnumerator SeeingPlayer()
    {
        _isSeeingPlayer = true;
        yield return new WaitForSeconds(1);

        if (_playerSpotted)
        {
            Destroy(Player);
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