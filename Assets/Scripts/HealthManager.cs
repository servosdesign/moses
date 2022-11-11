using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
  public int currentHealth;
  public int maxHealth;

  void Start()
  {

  }

  void Update()
  {

  }

  public void HurtPlayer(int damageToGive)
  {
    currentHealth -= damageToGive;
    if (currentHealth <= 0)
    {
      gameObject.SetActive(false);
    }
  }
}
