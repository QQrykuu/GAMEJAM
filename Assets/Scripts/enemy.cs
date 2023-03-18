using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : HealthSystem
{
    float speed = 1f;
    Transform Player;

    void Start()
    {

        if(GameObject.FindGameObjectWithTag("Player"))
        {
            Player = GameObject.FindWithTag("Player").transform;
        }

    }
    void Update()
    {
        if (Player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var thishs = this.GetComponent<HealthSystem>();
        if (collision.collider.CompareTag("Player"))
        {
            HealthSystem hs = Player.GetComponent<HealthSystem>();
            hs.Damage(1);
            thishs.Damage(1);
        }
        if (thishs.healthAmount == 0)
        {
            Dead();
        }

    }
    public void Dead()
    {
        Destroy(gameObject);
    }




}
