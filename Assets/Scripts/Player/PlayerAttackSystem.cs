using System.Linq;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    [Header("Private")]
    [SerializeField]private Transform attackPoint;
    [SerializeField]private LayerMask EnemyLayer;
    [SerializeField]private Animator animator;

    [Header("Public")]
    public float AttackDamage;
    public float AttackRange;
    public float AttackSpeed;
    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        //ReposSide(attackPoint.transform.eulerAngles.z);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AttackAnimation(attackPoint.transform.eulerAngles.z);
            Attack();
        }
    }
    private void ReposSide(float Angle)
    {
        if (Angle <= 45f || Angle >= 315f)
        {
            Debug.Log("right");
        }
        //Up
        if (Angle > 45f && Angle < 135f)
        {
            Debug.Log("Up");
        }
        //Left
        if (Angle >= 135 && Angle <= 225f)
        {
            Debug.Log("Left");
        }
        //Down
        if (Angle > 225f && Angle < 315f)
        {
            Debug.Log("Down");
        }
    }
    private void AttackAnimation(float Angle)
    {
        //right
        if (Angle <= 45f || Angle >= 315f)
        {
           // Debug.Log("right attack");
            animator.SetTrigger("AttackRight");
        }
        //Up
        if (Angle > 45f && Angle < 135f)
        {
           // Debug.Log("Up attack");
            animator.SetTrigger("AttackUp");
        }
        //Left
        if (Angle >= 135 && Angle <= 225f)
        {
           // Debug.Log("Left attack");
            animator.SetTrigger("AttackLeft");
        }
        //Down
        if (Angle > 225f && Angle < 315f)
        {
           // Debug.Log("Down attack");
            animator.SetTrigger("AttackDown");
        }
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, AttackRange, EnemyLayer);
            //Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, nemyLayer);

        Debug.Log(hitEnemies.Length);
        foreach (CapsuleCollider2D enemies in hitEnemies)
        {
            if (enemies.GetComponent<EnemyHealth>() != null)
                Debug.Log("obama");
        }


           /* Debug.Log("obama");
            if (count.TryGetComponent<EnemyHealth>(out EnemyHealth hp))
            {
                hp.TakeDamage(AttackDamage);
            }*/
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
    }
}