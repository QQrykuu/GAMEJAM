using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Coll_Objects
{
    public int damage = 1;
    public float pushForce = 0.5f;
    public float cooldown = 0.5f;
    private float lastAttack;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastAttack > cooldown)
            {
                lastAttack = Time.time;
                Swing();
            }
        }
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            if(coll.name == "Player_plho")
            {
                return;
            }
            Damage dmg = new Damage
            {
                damaged = damage,
                orign = transform.position,
                knockback = pushForce,

            };
            coll.SendMessage("Damaged", dmg);
        }
    }
    private void Swing()
    {
        anim.SetTrigger("Swing");
    }

}
