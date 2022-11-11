using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
  private HealthManager healthManager;
  public Slider healthBar;
  public TextMeshProUGUI hpText;

  void Start()
  {
    healthManager = FindObjectOfType<HealthManager>();
  }

  void Update()
  {
    healthBar.maxValue = healthManager.maxHealth;
    healthBar.value = healthManager.currentHealth;
    hpText.text = "HP: " + healthManager.currentHealth + "/" + healthManager.maxHealth;
  }
}
