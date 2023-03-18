using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 1;
    [SerializeField]Transform Player;
    private HealthSystem HealthSystem;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HealthSystem = GetComponent<HealthSystem>();
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
        if(Player !=null)
        {
            //collided with a building
            HealthSystem healthSystem = Player.GetComponent<HealthSystem>();
            healthSystem.Damage(1);
            this.HealthSystem.Damage(9999);
        }
    }
}
