using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    public Slider healthBar;
    public Text healthText;
    public float maxHealth = 100f;
    private float currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void SetHealth(float health)
    {
        maxHealth = health;
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthBar.value = currentHealth / maxHealth;
        healthText.text = $"{currentHealth} / {maxHealth}";
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthUI();
    }



}