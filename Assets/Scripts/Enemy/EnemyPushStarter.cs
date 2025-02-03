using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPushStarter : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject pointX1;
    [SerializeField] GameObject pointX2;
    [SerializeField] private int enemyQuantity;

    void EnemySpawn()
    {
        if (enemyQuantity > 0)
        {
            StartCoroutine(Wait());
            enemyQuantity--;
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            EnemySpawn();
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0);
        Vector3 position = new Vector3(Random.Range(pointX1.transform.position.x, pointX2.transform.position.x), pointX1.transform.position.y, 1);
        Instantiate(Enemy, position, transform.rotation);
        EnemySpawn();
    }

}
