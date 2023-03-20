using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : HealthSystem
{
    [SerializeField]float speed = 1f;
    Transform Player;
    [SerializeField] int dmg;
    
    [SerializeField] private GameObject dead;

    private Transform visual;
    void Start()
    {
        visual = transform.Find("Visual");

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

        Vector2 scale = visual.localScale;
        if (Player.position.x > transform.position.x)
        {
            scale.x = -1;

        }
        else
        {
            scale.x = 1f;
        }
        visual.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var thishs = this.GetComponent<HealthSystem>();
        if (collision.collider.CompareTag("Player"))
        {
            HealthSystem hs = Player.GetComponent<HealthSystem>();
            hs.Damage(dmg);
            thishs.Damage(1);
        }
        if (thishs.healthAmount == 0)
        {
            Dead();
        }

    }
    public void Dead()
    {
        GameObject deadEnemy = Instantiate(dead, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }




}
