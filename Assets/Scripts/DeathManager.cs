using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private SoundManager soundManager;
    public AudioClip playerKilledSound;
    public GameObject player;
    public GameObject spawnCords;
    public Vector2 spawnPoint;

    public static bool playerKilled;
    public static bool playerRespawn;
    private bool runOnce = false;

    void Start()
    {
        soundManager = GetComponent<SoundManager>();
        playerKilled = false;
        spawnPoint = spawnCords.transform.position;
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
        }
        else if (player.activeInHierarchy == false)
        {
            playerKilled = true;
        }
        if (playerKilled)
        {
            StartCoroutine(RespawnPlayer());
            playerKilled = false;
            playerRespawn = true;
        }

    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1f);
        player.SetActive(true);
        player.transform.position = spawnPoint;
    }
}