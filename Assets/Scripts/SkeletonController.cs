using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    private SoundManager soundManager;
    private Animator myAnimation;
    private Transform target;
    public Transform homePosition;
    public AudioClip enemyHit;

    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float maxRange = 0f;
    [SerializeField]
    private float minRange = 0f;

    void Start()
    {
        homePosition.parent = null;
        myAnimation = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
        soundManager = GetComponent<SoundManager>();
    }

    void Update()
    {
        if (!DeathManager.playerKilled)
        {
            if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
            {
                FollowPlayer();
            }
            else if (Vector3.Distance(target.position, transform.position) >= maxRange)
            {
                ReturnPosition();
            }
        }
        if (DeathManager.playerKilled)
        {
            ReturnPosition();
        }
    }

    public void FollowPlayer()
    {
        myAnimation.SetBool("isMoving", true);
        myAnimation.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnimation.SetFloat("moveY", (target.position.y - transform.position.y));

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void ReturnPosition()
    {
        myAnimation.SetFloat("moveX", (homePosition.position.x - transform.position.x));
        myAnimation.SetFloat("moveY", (homePosition.position.y - transform.position.y));

        transform.position = Vector3.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePosition.position) == 0)
        {
            myAnimation.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);

            soundManager.PlayEnemyHitSound(enemyHit);
        }
    }
}
