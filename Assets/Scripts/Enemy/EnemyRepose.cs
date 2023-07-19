using UnityEngine;

public class EnemyRepose : MonoBehaviour
{


    [Header("Random Range of max/min Coordinats")]
    [SerializeField] private float minX = -5f; // минимальное значение по X
    [SerializeField] private float maxX = 5f; // максимальное значение по X
    [SerializeField] private float minY = -5f; // минимальное значение по Y
    [SerializeField] private float maxY = 5f; // максимальное значение по Y

    [Header("")]
    [SerializeField] private float delayTime = 2f; // время задержки после перемещения
    [SerializeField] private float speed;

    //private
    private Vector3 targetPosition; // целевая позиция
    private bool isMoving = false; // флаг для проверки, двигается ли объект в данный момент
    private float currentDelayTime = 0f; // текущее время задержки
    private SpriteRenderer sprite;
    private Animator animator;

    //public
    public float moveSpeed = 2f; // скорость перемещения

    private void Start()
    {   animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        SetNewTargetPosition();

    }

    private void Update()
    {
        if (isMoving)
        {
            animator.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                isMoving = false;
                currentDelayTime = 0f;
            }
        }
        else 
        {
            animator.SetBool("isMoving", false);
            currentDelayTime += Time.deltaTime;
            if (currentDelayTime >= delayTime)
            {
                SetNewTargetPosition();
            }
        }
    }

    private void SetNewTargetPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector3(randomX, randomY, 0);
        isMoving = true;
        if (transform.position.x + randomX < transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}