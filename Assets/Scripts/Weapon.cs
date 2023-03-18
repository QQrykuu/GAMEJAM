using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 1;
    public float pushForce = 1f;
    public float cooldown = 0.75f;
    private float lastAttack;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    [SerializeField] Transform Enemy;
    private HealthSystem HealthSystem;
    
    protected  void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        HealthSystem = Enemy.GetComponent<HealthSystem>();
    }
    
    protected void Update()
    {
        
        if(Input.GetKey(KeyCode.Space))
        {
            
            if(Time.time - lastAttack > cooldown)
            {
                lastAttack = Time.time;
                
                Swing();
            }
        }
    }

    private void Swing()
    {
        anim.SetTrigger("Swing");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            HealthSystem healthSystem = Enemy.GetComponent<HealthSystem>();
            healthSystem.Damage(1);  
        }
    }
}
