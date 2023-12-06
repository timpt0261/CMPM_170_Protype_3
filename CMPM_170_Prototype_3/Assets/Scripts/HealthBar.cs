using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float currentHealth = 100f;
    [SerializeField] Image fillImage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth -= Time.deltaTime;
        UpdateHealth();
        
    }

    private void UpdateHealth()
    {
        fillImage.fillAmount = currentHealth / 100;
    }
}
