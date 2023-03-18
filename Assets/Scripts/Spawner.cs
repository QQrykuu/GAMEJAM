using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private Transform[] spawnpoints;
    [SerializeField]private GameObject enemiesPref;
    [SerializeField] private float betweenSpawn = 5f;
    void Start()
    {
        StartCoroutine(spawnEnemies(betweenSpawn, enemiesPref));
    }

    
    void Update()
    {
        //int rEnemy = Random.Range(0, enemiesPref.Length);
        //int rSpawnPoint = Random.Range(0, spawnpoints.Length);
        /*  if(Input.GetKeyDown(KeyCode.B))
          {


              Instantiate(enemiesPref[rEnemy], spawnpoints[rSpawnPoint].position, transform.rotation);
          }
        */
    }
    private IEnumerator spawnEnemies(float interval,GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-5f, 5), 0), Quaternion.identity);
        StartCoroutine(spawnEnemies(interval, enemy));
    }
}
