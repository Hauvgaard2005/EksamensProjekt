using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUi : MonoBehaviour
{
    public float curHealth;
    public float lerpTimer;
    public float maxHealth = 100f;
    public Image healthBar;
    public Image staminaBar;

    public void Start()
    {
        
        curHealth = maxHealth;
        UpdateHealthUI();
    }

    public void SetHealth(float health)
    {
        maxHealth = health;
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        curHealth -= damageAmount;
        curHealth = Mathf.Clamp(curHealth, 0f, maxHealth);
        UpdateHealthUI();
    }



}