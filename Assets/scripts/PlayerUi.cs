using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUi : MonoBehaviour
{
    public Player player;
    public float curHealth;
    public float lerpTimer;
    public float chipSpeed = 20f;
    public float maxHealth = 100f;
    public float maxStamina = 3f;

    public Image frontHealthBar;
    public Image backHealthBar;
    public Image staminaBar;

    float fillF;
    float fillB;
    float hFraction;
    float fillS;

    public void Awake()
    {
    
        frontHealthBar = GameObject.FindGameObjectWithTag("FrontHealthBar").GetComponent<Image>();
        backHealthBar = GameObject.FindGameObjectWithTag("BackHealthBar").GetComponent<Image>();
        staminaBar = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<Image>();
        curHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        

        // UpdatePlayerUi(curHealth);
    }

    /*public void SetHealth(float currentHealth)
    {
        curHealth = currentHealth;
        UpdatePlayerUi(curHealth);
    }*/

    public void UpdatePlayerUi(float currentHealth)
    {

        fillF = frontHealthBar.fillAmount;
        fillB = backHealthBar.fillAmount;

        hFraction = currentHealth / maxHealth;

        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        fillS = staminaBar.fillAmount;
        staminaBar.fillAmount = player.stamina / player.dashCooldown;

    }

    public void TakeDamage(float damageAmount)
    {
        curHealth -= damageAmount;
        curHealth = Mathf.Clamp(curHealth, 0f, maxHealth);
        UpdatePlayerUi(curHealth);
    }



}