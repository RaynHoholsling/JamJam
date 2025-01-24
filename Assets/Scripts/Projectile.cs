using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity;
    public int damage;

    private void Update()
    {
        if ((transform.position.x >= 500 || transform.position.x <= -500) || (transform.position.y >= 500 || transform.position.y <= -500))
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider != null) && (collision.collider.CompareTag("Player") == false))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy>().Die();
            }
            else if (collision.gameObject.CompareTag("EnemyStatic"))
            {
                collision.gameObject.GetComponent<EnemyStatic>().Die();
            }
            else if (collision.gameObject.CompareTag("EnemyInWave"))
            {
                collision.gameObject.GetComponent<EnemyInWave>().Die();
            }
            
            Destroy(gameObject);
        }
    }
}
