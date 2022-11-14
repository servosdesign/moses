using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthManage;

    public float waitToHurt = 0.7f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10;

    void Start()
    {
        healthManage = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        /*
        if (reloading)
        {
          waitToLoad -= Time.deltaTime;
          if (waitToLoad <= 0)
          {
            SceneManager.LoadScene("MainMenu");
          }
        }
        */

        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthManage.HurtPlayer(damageToGive);
                waitToHurt = 0.7f;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);

            // reloading = true;
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
