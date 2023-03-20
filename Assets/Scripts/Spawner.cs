using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private GameObject[] Boss;
    [SerializeField] private GameObject[] enemiesPref;
    [SerializeField] private float betweenSpawn = 5f;
    [SerializeField] int AmountOfEnemies;
    
    int enemiesSpawned = 0;
    void Start()
    {
        StartCoroutine(spawnEnemies(betweenSpawn, enemiesPref, Boss));

        
    }


    void Update()
    {
        
       

      
    }
    private IEnumerator spawnEnemies(float interval, GameObject[] enemies, GameObject[] Bosses)
    {
        yield return new WaitForSeconds(interval);
       
        
            if (enemiesSpawned < AmountOfEnemies)
            {
                var enemy = enemies[Random.Range(0, enemiesPref.Length)];
                GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5) + transform.position.x, Random.Range(-5f, 5) + transform.position.y, 0), Quaternion.identity);

            }
            StartCoroutine(spawnEnemies(interval, enemies, Bosses));
            enemiesSpawned = enemiesSpawned + 1;
            if (enemiesSpawned > AmountOfEnemies)
            {
                enemiesSpawned = 0;
                var bosses = Bosses[Random.Range(0, Boss.Length)];

                GameObject newBoss = Instantiate(bosses, new Vector3(Random.Range(-5f, 5) + transform.position.x, Random.Range(-5f, 5) + transform.position.y, 0), Quaternion.identity);
                Destroy(gameObject);
            }
        
    }
}
