using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 1;
    public float pushForce = 1f;
    public float cooldown = 0.75f;
    private bool lastAttack;
    Transform Player;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    
    protected  void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    protected void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {        
            Swing();
        }
    }

    private void Swing()
    {
        if(lastAttack)
        {
            return;
        }
        anim.SetTrigger("Swing");
        lastAttack = true;
        StartCoroutine(Cooldown());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealthSystem hs = collision.gameObject.GetComponent<HealthSystem>();
            hs.Damage(1);
            if (hs.healthAmount == 0)
            {
                collision.gameObject.GetComponent<enemy>().Dead();
            }
        }
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        lastAttack = false;
    }
}
