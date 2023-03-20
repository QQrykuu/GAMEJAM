using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private float timer;
    [SerializeField] float accuracy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 dir = Player.transform.position - transform.position;
        rb.velocity = new Vector2(Random.Range(-accuracy,accuracy) + dir.x, Random.Range(-accuracy, accuracy) + dir.y).normalized * speed;

        float rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthSystem hs = Player.GetComponent<HealthSystem>();
            hs.Damage(1);

            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
