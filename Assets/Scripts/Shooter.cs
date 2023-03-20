using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectilePos;
    private GameObject Player;
    private float timer;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, Player.transform.position);
        Debug.Log(distance);
        if (distance < 15)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }


    }
    void Shoot()
    {
        Instantiate(projectile, projectilePos.position, Quaternion.identity);
    }
}
