using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private new void Start()
    {
        base.Start();
    }
    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
