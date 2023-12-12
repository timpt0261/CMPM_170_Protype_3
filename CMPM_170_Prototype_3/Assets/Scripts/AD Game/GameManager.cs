using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int INITIALHEALTH = 100;
    int INITIALMONEY = 0;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI MoneyText;
    [SerializeField] private int currentHealth;
    [SerializeField] private int currentMoney;


    private void Start()
    {
        
        currentHealth = INITIALHEALTH;
        currentMoney = INITIALMONEY;
        healthBar.value = currentHealth;
        MoneyText.text = "$" + currentMoney.ToString();

    }

    private void Update()
    {
        TestInput();
    }

    private void TestInput()
    {
        var keyboard = Keyboard.current;
        if (keyboard.zKey.isPressed)
        {
            ModifyHealth(-1);
            ModifyMoney(1);
        }
    }

    private void ModifyHealth(int amount)
    {
        currentHealth += amount;
        healthBar.value = currentHealth;
    }

   private void ModifyMoney(int amount)
    {
        currentMoney += amount;
        MoneyText.text = "$" + currentMoney.ToString();
    }
    //For Gabe <30330301-3i012904531-04 vvvvvvvvvv
    public void ApplyAd()
    {

    }

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }



    
}
