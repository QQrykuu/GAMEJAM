using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    [SerializeField] private float deadTime;
    [SerializeField] private GameObject[] potions;
    private GameObject currentPotion;

    int index;
    void Start()
    {
        StartCoroutine(destroy(deadTime));
    }


    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PickUp();
            Destroy(gameObject);
        }
    }
    private IEnumerator destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    private void PickUp()
    {
        index = Random.Range(0, potions.Length);
        currentPotion = potions[index];
        GameObject newPotions = Instantiate(currentPotion, new Vector3(Random.Range(gameObject.transform.position.x - 1f, gameObject.transform.position.x + 1f), Random.Range(gameObject.transform.position.y - 1f, gameObject.transform.position.y + 1f)), Quaternion.identity);
    }

}
