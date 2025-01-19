using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Animations;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject machinegun;
    [SerializeField] private GameObject weaponControle;
    public bool _ammoCrateIsAvailable;
    Animator animator;
    Vector2 movement;
    [SerializeField] private GameObject _deadBody;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    //if (collision.CompareTag("warningTrigger"))
    //    Destroy(other.gameObject);      
    //}

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (animator)
        {
            animator.SetBool("Run", Mathf.Abs(movement.x) >= 0.1f);
        }
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!facingRight && mousePosition.x > transform.position.x)
        {
            Flip();
        }
        else if (facingRight && mousePosition.x < transform.position.x)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    //private void OnDestroy()
    //{
    //    StartCoroutine(Deading());      
    //}
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Vector3 WeaponScaler = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Transform>().localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        WeaponScaler.x *= -1;
        WeaponScaler.y *= -1;
        GameObject.FindGameObjectWithTag("Weapon").GetComponent<Transform>().localScale = WeaponScaler;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Level2Trigger"))
        {
            Debug.Log("Helolo");
            SceneManager.LoadScene(1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        bool machinegunEnebled = false;
        if (collision.tag == "MachineGun" && Input.GetKeyDown(KeyCode.E))
        {
            weaponControle.SetActive(false);
            machinegun.GetComponent<MachineGun>().enabled = true;
            machinegunEnebled = true;
        }
        else if(collision.tag == "MachineGun" && Input.GetKeyDown(KeyCode.E) && machinegunEnebled == true)
        {
            weaponControle.SetActive(true);
            machinegun.GetComponent<MachineGun>().enabled = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("AmmoCrate"))
        {
            _ammoCrateIsAvailable = true;
        }
        
    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("AmmoCrate"))
        {
            _ammoCrateIsAvailable = false;
        }
    }
    public void Die()
    {
        Instantiate(_deadBody, transform.position, Quaternion.identity);
        StartCoroutine(Deading());
    }

    IEnumerator Deading()
    {
        yield return new WaitForSeconds(1);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
