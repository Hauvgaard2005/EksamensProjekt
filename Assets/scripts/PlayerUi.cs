using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUi : MonoBehaviour
{
    public float curHealth;
    public float lerpTimer;
    public float chipSpeed = 0.5f;
    public float maxHealth = 100f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public Image staminaBar;

    public void Start()
    {
        frontHealthBar = GameObject.FindGameObjectWithTag("FrontHealthBar").GetComponent<Image>();
        backHealthBar = GameObject.FindGameObjectWithTag("BackHealthBar").GetComponent<Image>();
        staminaBar = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<Image>();
        curHealth = maxHealth;
        UpdateHealthUI();
    }

    public void SetHealth(float currentHealth)
    {
        maxHealth = curHealth;
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = curHealth / maxHealth;
        Debug.Log(hFraction);
        
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        float fillS = staminaBar.fillAmount;



    }

    public void TakeDamage(float damageAmount)
    {
        curHealth -= damageAmount;
        curHealth = Mathf.Clamp(curHealth, 0f, maxHealth);
        UpdateHealthUI();
    }



}