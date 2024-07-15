using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Knife : MonoBehaviour
{
    private GameObject _enemy;
    [SerializeField] private bool _isTouchingEnemy = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enemy = collision.gameObject;
        _isTouchingEnemy = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isTouchingEnemy = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isTouchingEnemy)
        {
            Destroy(_enemy);
        }
    }
}
