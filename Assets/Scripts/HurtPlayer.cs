using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthManager;
    private SoundManager soundManager;
    public AudioClip playerHitSound;

    public float waitToHurt = 0.7f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10;

    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        soundManager = GetComponent<SoundManager>();
    }

    void Update()
    {
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthManager.HurtPlayer(damageToGive);
                waitToHurt = 0.7f;
                soundManager.PlayPlayerHitSound(playerHitSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
            soundManager.PlayPlayerHitSound(playerHitSound);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2;
        }
    }
}
