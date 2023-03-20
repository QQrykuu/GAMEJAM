using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float x;
    float y;
    Rigidbody2D rb;
    public float PlayerSpeed = 4f;
    [SerializeField]Transform visual;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
    }

    
    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        rb.velocity = (new Vector3(x * PlayerSpeed, y * PlayerSpeed,0));
    }
  

}
