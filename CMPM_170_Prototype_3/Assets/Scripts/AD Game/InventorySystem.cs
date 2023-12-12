using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    //Lets give it a default image so that once the ad type is displayed it goes to that
    //And our code here checks for it and updates it if need be
    [SerializeField] private GameObject[] adSlots;
    [SerializeField] private AdType[] adtypes;
    void Start()
    {
        AdInitialization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AdInitialization()
    {
        foreach (GameObject slot in adSlots)
        {
            Ad adFromSlot = slot.GetComponent<Ad>();
            AdType type = adtypes[Random.Range(0, adtypes.Length-1)];
            adFromSlot.SetAndRandomize(type);
        }
    }
    private void AdRandomization()
    {
        GameObject randomSlot = adSlots[Random.Range(0, adSlots.Length-1)];
        AdType randomAdtype = adtypes[Random.Range(0, adtypes.Length - 1)];
        Ad adFromSlot = randomSlot.GetComponent<Ad>();
        adFromSlot.SetAndRandomize(randomAdtype);
    }
}
