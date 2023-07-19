using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]protected float MaxHealth;
    [SerializeField]protected float currentHealth;


    public abstract void TakeDamage(float damage);

    public virtual void Start()
    {
        currentHealth = MaxHealth;
    }

}
