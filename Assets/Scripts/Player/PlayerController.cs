using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private float speed; //2.1
    private Vector2 moveDirection;
    private Rigidbody2D Rigidbody;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + moveDirection * speed * Time.deltaTime);
    }
}
