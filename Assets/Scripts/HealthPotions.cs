using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotions : MonoBehaviour
{
    Transform Player;
    [SerializeField] private int heal;
    [SerializeField] float displayTime;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Player = GameObject.FindWithTag("Player").transform;
        }
        StartCoroutine(destroy(displayTime));
    }


    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            HealthSystem hs = Player.GetComponent<HealthSystem>();
            hs.Heal(heal);
            Destroy(gameObject);
        }

    }
    private IEnumerator destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
