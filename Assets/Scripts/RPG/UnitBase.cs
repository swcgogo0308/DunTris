using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBase : MonoBehaviour,IUnitHandler
{
    enum Attribute
    {
        Fire,
        Water,
        Earth
    }

    Attribute attribute;

    public int maxHealth;
    public int damageAmount;
    public int healAmount;

    
    public abstract void Attack();
    public abstract void OnDamage(int damage);
    public abstract void Death();
}
