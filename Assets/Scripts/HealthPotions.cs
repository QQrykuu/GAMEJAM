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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
