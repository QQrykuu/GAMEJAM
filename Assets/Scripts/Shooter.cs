using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectilePos;
    private GameObject Player;
    private float timer;
    [SerializeField] float delay;
    [SerializeField] int burst;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, Player.transform.position);
        
        if (distance < 8)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                timer = 0;
                Shoot();
            }
        }


    }
    void Shoot()
    {
        if (burst == 0)
        {
            Instantiate(projectile, projectilePos.position, Quaternion.identity);
        }
        else
        {
            for(int i = 0; i <= burst; i++)
            {
                Instantiate(projectile, projectilePos.position, Quaternion.identity);
            }

        }
    }
}
