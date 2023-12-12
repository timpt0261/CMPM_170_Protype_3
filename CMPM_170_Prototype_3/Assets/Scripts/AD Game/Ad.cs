using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Ad : MonoBehaviour
{
    private string type;
    [SerializeField] private Image Img;
    private Sprite defaultSprite;
    int moneyImpact;
    int AttentionImpact;
    Vector2 initialPos;

    void Start()
    {
        type = "";
        defaultSprite = Img.sprite;
        moneyImpact = 0;
        AttentionImpact = 0;
        initialPos = gameObject.transform.position;
        Debug.Log(initialPos);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAndRandomize(AdType adtype)
    {
        type = adtype.type;
        Img.sprite = adtype.adSprite;
        switch (type)
        {
            case "Good":
                moneyImpact = Random.Range(100, 300);
                AttentionImpact = Random.Range(10, 20);
                break;
            case "Bad":
                moneyImpact = Random.Range(-200, -100);
                AttentionImpact = Random.Range(-10, -20);
                break;
            case "Glorious":
                moneyImpact = 1000;
                AttentionImpact = 50;
                break;
        }
        
        
    }
    private void Reset()
    {
        type = "";
        Img.sprite = defaultSprite;
    }
}
