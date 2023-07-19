using UnityEngine;

public class EnemyHealth : Health
{   
    public new void Start()
    {
        base.Start();
    }
    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
    }
    private void Die() { }
}
