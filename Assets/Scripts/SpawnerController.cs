using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    //[SerializeField] Transform[] doors;
    [SerializeField] Transform[] spawners;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        //foreach(Transform triggered in doors)
        //{
        //    triggered.GetComponent<Door>().unlocked = false;
        //    triggered.GetComponent<Door>().DoorControl.gameObject.SetActive(true);
        //}
        foreach(Transform trigg in spawners)
        {
            trigg.gameObject.SetActive(true);
            
        }
    }
}
