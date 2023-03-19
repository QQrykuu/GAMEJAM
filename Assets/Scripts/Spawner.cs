using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private Transform[] spawnpoints;
    [SerializeField]private GameObject[] enemiesPref;
    [SerializeField]private float betweenSpawn = 5f;
    void Start()
    {
        StartCoroutine(spawnEnemies(betweenSpawn, enemiesPref));
    }

    
    void Update()
    {

    }
    private IEnumerator spawnEnemies(float interval,GameObject[] enemies)
    {
        yield return new WaitForSeconds(interval);
        var enemy = enemies[Random.Range(0, enemiesPref.Length)];
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(gameObject.transform.position.x - 20f, gameObject.transform.position.x + 20f), Random.Range(gameObject.transform.position.y - 2f, gameObject.transform.position.y + 5f)), Quaternion.identity);
        StartCoroutine(spawnEnemies(interval, enemies));
    }
}
