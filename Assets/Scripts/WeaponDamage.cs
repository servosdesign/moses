using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int swordDamageAmount = 2;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealthManager eHealManager;
            eHealManager = other.gameObject.GetComponent<EnemyHealthManager>();
            eHealManager.HurtEnemy(swordDamageAmount);
        }
    }
}
