using UnityEngine;

public class Knife : MonoBehaviour
{
    private GameObject _enemy;
    [SerializeField] private bool _isTouchingEnemy = false;
    [SerializeField] private bool _isTouchingEnemyStatic = false;
    [SerializeField] private AudioSource _knifeSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _isTouchingEnemy = true;
            _enemy = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("EnemyStatic"))
        {
            _isTouchingEnemyStatic = true;
            _enemy = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isTouchingEnemy = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _knifeSound.Play();
        }
        if (Input.GetMouseButtonDown(0) && _isTouchingEnemy)
        {
            _enemy.GetComponent<Enemy>().Die();
        }

        if (Input.GetMouseButtonDown(0) &&  _isTouchingEnemyStatic) 
        {
            _enemy.GetComponent<EnemyStatic>().Die();
        }
    }
}
