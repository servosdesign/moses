using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject cutsceneManager;
    private Rigidbody2D playerRigidbody;
    private Animator playerMovementAnim;
    private NPCController npc;
    private CutsceneController cutscene;
    private AudioSource footstepAudio;

    [SerializeField]
    private float movementSpeed = 0f;
    [SerializeField]
    private float animationSpeed = 0f;
    private float attackTime = 0.1f;
    private float attackCounter = 0.25f;
    private bool isAttacking;
    private bool inNPCarea;
    private bool killable;

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

            if (inNPCarea && Input.GetKeyDown("e"))
            {
                npc.ActivateDialogue();
            }

            if (inNPCarea && killable && Input.GetKeyDown("space"))
            {
                Debug.Log("killed");
                cutscene.KilledCutscene();
            }
            if (inNPCarea && killable && Input.GetKeyDown("v"))
            {
                Debug.Log("spared");
                cutscene.SparedCutscene();
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

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "NPC" || other.gameObject.tag == "NPC2")
        {
            inNPCarea = true;
            npc = other.gameObject.GetComponent<NPCController>();
            cutscene = cutsceneManager.GetComponent<CutsceneController>();

            if (other.gameObject.tag == "NPC2")
            {
                killable = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        npc = null;
        inNPCarea = false;
        killable = false;
    }
}
