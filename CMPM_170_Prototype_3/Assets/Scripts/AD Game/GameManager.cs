using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int INITIALRETENTION = 100;
    int INITIALMONEY = 0;
    [SerializeField] private Slider retentionBar;
    [SerializeField] private TextMeshProUGUI MoneyText;
    [SerializeField] private int currentRetention;
    [SerializeField] private int currentMoney;
    [SerializeField] private GameObject Timer;

    //NOTE: Health is relating to when the player gives bad ads 

    private void Start()
    {
        
        currentRetention = INITIALRETENTION;
        currentMoney = INITIALMONEY;
        retentionBar.value = currentRetention;
        MoneyText.text = "$" + currentMoney.ToString();
        StartCoroutine(RetentionDecayOverTime());
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
            modifyRetention(-1);
            ModifyMoney(1);
        }
    }

    private IEnumerator RetentionDecayOverTime()
    {
        while (currentRetention > 0)
        {
            currentRetention -= 1;
            retentionBar.value = currentRetention;
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("GameOver");
        
    }

    private void modifyRetention(int amount)
    {
        currentRetention += amount;
        retentionBar.value = currentRetention;
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
        return currentRetention;
    }



    
}
