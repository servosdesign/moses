using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator playerMovementAnim;

    [SerializeField]
    private float movementSpeed = 0f;
    [SerializeField]
    private float animationSpeed = 0f;
    private float attackTime = 0.25f;
    private float attackCounter = 0.25f;
    private bool isAttacking;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerMovementAnim = GetComponent<Animator>();
    }

    void Update()
    {
        playerMovementAnim.SetFloat("moveX", playerRigidbody.velocity.x);
        playerMovementAnim.SetFloat("moveY", playerRigidbody.velocity.y);

        playerMovementAnim.speed = animationSpeed;

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerMovementAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerMovementAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        if (isAttacking)
        {
            attackCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            attackCounter = attackTime;
            playerMovementAnim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    void FixedUpdate()
    {
        playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * movementSpeed * Time.deltaTime;
    }
}
