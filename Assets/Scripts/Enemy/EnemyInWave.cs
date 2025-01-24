using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInWave : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    Animator animator;
    [SerializeField] private float followSpeed;
    [SerializeField] private GameObject _deadBody;

    void Start()
    {     
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator)
        {
            animator.SetBool("Run", true);
        }
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 50), followSpeed * Time.deltaTime);
    }
    public void Die()
    {
        Instantiate(_deadBody, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
