using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnHealthAmountMaxChanged;
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;    
    public event EventHandler OnDied;
    [SerializeField]public float healthAmountMax;
    public float healthAmount;
    private void Awake()
    {
        healthAmount = healthAmountMax;
    }
    public void SetHealthAmountMax(float healthAmountMax, bool UpdateHealthAmount)
    {
        this.healthAmountMax = healthAmountMax;
        if (UpdateHealthAmount)
        {
            healthAmount = healthAmountMax;
        }

        OnHealthAmountMaxChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Damage(int damageAmount)
    {
        healthAmount -= damageAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmountMax);

        OnDamaged?.Invoke(this, EventArgs.Empty);

        if(IsDead())
        {
            OnDied?.Invoke(this, EventArgs.Empty);
            
        }
    }
    public void Heal(int HealAmount)
    {
        healthAmount += HealAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmountMax);

        OnHealed.Invoke(this, EventArgs.Empty);
    }
    public void HealFull()
    {
        healthAmount = healthAmountMax;

        OnHealed.Invoke(this, EventArgs.Empty);
    }

    public bool IsDead()
    {
        return healthAmount == 0;
    }
    
    public bool IsFullHealth()
    {
        return healthAmount == healthAmountMax;
    }

    public float GetHealthAmount()
    {
        return healthAmount;
    }
    public float GetHealthAmountMax()
    {
        return healthAmountMax;
    }
    public float GetHealthAmountNormalised()
    {
        return (float)healthAmount / healthAmountMax;
    }

}
