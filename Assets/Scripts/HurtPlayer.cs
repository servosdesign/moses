using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
  private float waitToLoad = 2f;
  private bool reloading;

  void Start()
  {

  }

  void Update()
  {
    if (reloading)
    {
      waitToLoad -= Time.deltaTime;
      if (waitToLoad <= 0)
      {
        SceneManager.LoadScene("MainMenu");
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.collider.tag == "Player")
    {
      other.gameObject.SetActive(false);
      reloading = true; 
    }
  }
}
