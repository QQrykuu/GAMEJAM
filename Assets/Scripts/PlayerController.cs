using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float x;
    float y;
    Rigidbody2D rb;
    float speed = 4f;
    [SerializeField]Transform visual;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        rb.velocity = (new Vector3(x * speed, y * speed,0));
    }
  

}
