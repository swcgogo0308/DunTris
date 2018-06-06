using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : UnitBase
{
    int currentHealth, currentDamageAmount, 
        currentHealAmount;

	void Start () {
        currentHealth = maxHealth;
	}
	
	void Update () {
		
	}

    public override void Attack()
    {
        //TODO ATTACK'S      
    }

    void Healing(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
    }

    public override void OnDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Death();
    }

    public override void Death()
    {
        Destroy(transform.gameObject);
    }

}
