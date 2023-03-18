using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 0f;
    [SerializeField]Transform Player;
    [SerializeField] Collider2D Target;
    private HealthSystem HealthSystem;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HealthSystem = GetComponent<HealthSystem>();
        Target = GetComponent<Collider2D>();
        
}
    void Update()
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
        if (Target != null)
        {


            HealthSystem healthSystem = Player.GetComponent<HealthSystem>();
            healthSystem.Damage(1);


        }
    }
    
    
    
}
