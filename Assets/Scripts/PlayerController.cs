using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator playerMovementAnim;
    private NPCController npc;
    private CutsceneController cutscene;

    [SerializeField]
    private float movementSpeed = 0f;
    [SerializeField]
    private float animationSpeed = 0f;
    private float attackTime = 0.1f;
    private float attackCounter = 0.25f;
    private bool isAttacking;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerMovementAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!InDialogue())
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
                if (attackCounter <= 0)
                {
                    playerMovementAnim.SetBool("isAttacking", false);
                    isAttacking = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackCounter = attackTime;
                playerMovementAnim.SetBool("isAttacking", true);
                isAttacking = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (!InDialogue())
        {
            playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * movementSpeed * Time.deltaTime;

            if (isAttacking)
            {
                playerRigidbody.velocity = Vector2.zero;
            }
        }
    }

    private bool InDialogue()
    {
        if (npc != null)
        {
            return npc.DialogueActive();
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "NPC" || other.gameObject.tag == "NPC2")
        {
            npc = other.gameObject.GetComponent<NPCController>();
            cutscene = other.gameObject.GetComponent<CutsceneController>();

            if (Input.GetKey(KeyCode.E))
            {
                npc.ActivateDialogue();
            }

            if (other.gameObject.tag == "NP2")
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("killed");
                    cutscene.KilledCutscene();
                }
                if (Input.GetKey(KeyCode.V))
                {
                    Debug.Log("spared");
                    cutscene.SparedCutscene();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        npc = null;
    }
}
