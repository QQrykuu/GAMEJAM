using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : HealthSystem
{
    Rigidbody2D rb;
    float speed = 1f;
    [SerializeField]Transform Player;
    private HealthSystem HealthSystem;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HealthSystem = GetComponent<HealthSystem>();
        
      
    }
    void LateUpdate()
    {
        HandleMovement();

    }
    private void HandleMovement()
    {
        if(Player != null)
        {
            Vector3 moveDir = (Player.position - transform.position).normalized;

            rb.velocity = moveDir*speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            HealthSystem healthSystem = Player.GetComponent<HealthSystem>();
            healthSystem.Damage(1);
        }
        if (healthAmount == 0)
        {
            Dead();
        }

    }
    public void Dead()
    {
        //Destroy(gameObject);
    }



}
