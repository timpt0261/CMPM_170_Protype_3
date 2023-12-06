using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float currentHealth = 100f;
    [Range(1, 10)]
    [SerializeField] private int multiplier = 1;
    [SerializeField] Image fillImage;
    
    void Start()
    {
        fillImage.fillAmount = currentHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) Debug.Log("GameOver");
        currentHealth -= Time.deltaTime * multiplier;
        UpdateHealth();
        
    }

    private void UpdateHealth()
    {
        UpdateHealthColor();
        fillImage.fillAmount = currentHealth;
    }

    private void UpdateHealthColor()
    {
        if (currentHealth < 20)
            fillImage.color = Color.red;
 
    }
}
