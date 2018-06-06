using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitHandler  {
    void Attack();
    void OnDamage(int damage);
    void Death();    
}
