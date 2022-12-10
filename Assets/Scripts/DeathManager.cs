using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private SoundManager soundManager;
    public AudioClip playerKilledSound;
    public GameObject player;
    private Vector2 spawnPoint;

    public static bool playerKilled;
    public static bool playerRespawn;
    private bool runOnce = false;

    void Start()
    {
        soundManager = GetComponent<SoundManager>();
        playerKilled = false;
        playerRespawn = false;
        spawnPoint = player.transform.position;
    }

    void Update()
    {
        if (!runOnce)
        {
            if (player.activeInHierarchy == false)
            {
                soundManager.PlayPlayerKilledSound(playerKilledSound);
                runOnce = true;
            }
            playerRespawn = false;
        }
        else if (player.activeInHierarchy == false)
        {
            playerKilled = true;
        }
        if (playerKilled)
        {
            resetHealth();
            StartCoroutine(RespawnPlayer());
            playerKilled = false;
        }
    }

    public void resetHealth()
    {
        playerRespawn = true;
    }


    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1f);
        player.SetActive(true);
        player.transform.position = spawnPoint;
    }
}