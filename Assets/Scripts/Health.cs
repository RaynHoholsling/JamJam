using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    private void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
       
        if(health <= 0)
        {
            Destroy(gameObject, .06f);
        }
    }   
}
