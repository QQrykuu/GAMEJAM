using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : HealthSystem
{
    [SerializeField]float speed = 1f;
    Transform Player;
    [SerializeField] int dmg;
    
    [SerializeField] private GameObject dead;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var thishs = this.GetComponent<HealthSystem>();
        if (collision.gameObject.CompareTag("Player"))
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
