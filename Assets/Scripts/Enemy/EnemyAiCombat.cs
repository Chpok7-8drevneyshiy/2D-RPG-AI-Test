using UnityEngine;

public class EnemyAiCombat : MonoBehaviour
{
    // Serializable
    [SerializeField] private float aggressionDistance;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float enemyMatesDistance;
    [SerializeField] private float enemyDamage;
    [SerializeField] private bool socialOrNot;
    [SerializeField] private LayerMask playerLayer, enemyLayer;

    //Collider2D
    private Collider2D Player;      //scan for player detection
    private Collider2D AttackRange;    
    private Collider2D[] EnemyMates;    

    //C# Scripts
    private EnemyRepose enemyRepose;
    private Animator animator;
    private SpriteRenderer sprite;

    //private variables
    private float time;
    private float speed;        // speed of Enemy
    private GameObject player; //Player

    //Public
    public bool Aggression;    //state


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        enemyRepose = GetComponent<EnemyRepose>();
        speed = enemyRepose.moveSpeed;
        time = 0;
    }
    private void Update()
    {
        time += Time.deltaTime;
        //Дистанция атаки
        if (Aggression) 
        {
            //SpriteFlip();
            AttackRange = Physics2D.OverlapCircle(transform.position, attackDistance, playerLayer);
            if (AttackRange == null) 
                {
                    Seek(player);
                }
            else
                {
                    animator.SetBool("isMoving", false);
                    Attack();
                }
        }
        if (!Aggression)
        {
            if (Player == null)
            {
                // Дистанция агра
                Player = Physics2D.OverlapCircle(transform.position, aggressionDistance, playerLayer);
                if (Player != null)
                {
                    Aggression = true;
                    player = Player.gameObject;

                    if (socialOrNot)
                    {
                        EnemyMates = Physics2D.OverlapCircleAll(transform.position, enemyMatesDistance, enemyLayer);
                        foreach (Collider2D enemies in EnemyMates)
                        {
                            enemies.GetComponent<EnemyAiCombat>().player = player;
                            enemies.GetComponent<EnemyAiCombat>().Aggression = true;
                        }
                    }
                }
            }
        }    
    }

    private void Attack()
    {
        if (time >= attackSpeed)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
            time = 0;
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aggressionDistance);
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        Gizmos.DrawWireSphere(transform.position, enemyMatesDistance);
    }

    private void Seek(GameObject player)
    {
        SpriteFlip();
        animator.SetBool("isMoving", true);
        enemyRepose.enabled = false;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void SpriteFlip()
    {
        if (player.transform.position.x < transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (player.transform.position.y > transform.position.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, -1), speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, 0), speed);
        }


    }
    private void FixedUpdate()
    {
        if (Aggression)
        SpriteFlip();
    }
}
