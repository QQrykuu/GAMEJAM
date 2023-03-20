using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    [SerializeField] private float deadTime;
    [SerializeField] private GameObject[] potions;
    private GameObject currentPotion;
    [SerializeField] private bool dropAll;

    int index;
    void Start()
    {
        StartCoroutine(destroy(deadTime));
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
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
        if (!dropAll)
        {
            index = Random.Range(0, potions.Length);
            currentPotion = potions[index];
            GameObject newPotions = Instantiate(currentPotion, new Vector3(Random.Range(gameObject.transform.position.x - 2f, gameObject.transform.position.x + 2f), Random.Range(gameObject.transform.position.y - 1f, gameObject.transform.position.y + 1f)), Quaternion.identity);
        }
        else
        {
            foreach(GameObject drop in potions)
            {
                GameObject newPotions = Instantiate(drop, new Vector3(Random.Range(gameObject.transform.position.x - 2f, gameObject.transform.position.x + 2f), Random.Range(gameObject.transform.position.y - 1f, gameObject.transform.position.y + 1f)), Quaternion.identity);
            }
        }
        
    }

}
