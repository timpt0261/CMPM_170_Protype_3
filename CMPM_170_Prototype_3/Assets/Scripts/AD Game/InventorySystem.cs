using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using Random = UnityEngine.Random;

public class InventorySystem : MonoBehaviour
{
    //Lets give it a default image so that once the ad type is displayed it goes to that
    //And our code here checks for it and updates it if need be
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject[] adSlots;
    [SerializeField] private AdType[] adtypes;
    [SerializeField] private GameObject[] adPrefabs;
    [SerializeField] private AudioSource audioDropSFX;
    private bool dragging = false;
    public GameObject uiCanvas;
    GraphicRaycaster uiRaycaster;
    PointerEventData clickData;
    List<RaycastResult> clickResults;
    List<GameObject> clickedElements;
    GameObject dragElement;
    Vector3 previousMousePos;

    Vector3 mousePos;
    void Start()
    {
        
        uiRaycaster = uiCanvas.GetComponent<GraphicRaycaster>();
        clickData = new PointerEventData(EventSystem.current);
        clickResults = new List<RaycastResult>();
        clickedElements = new List<GameObject>();
        AdInitialization();
    }

    // Update is called once per frame
    void Update()
    {
        MouseDragUI();
    }

    private void MouseDragUI()
    {
        mousePos = Mouse.current.position.ReadValue();

        if(Mouse.current.leftButton.wasPressedThisFrame )
        {
            GetUIElementsClicked();
        }

        if (Mouse.current.leftButton.isPressed && dragging)
        {
            DragAd();
        } else
        {
            dragging = false;
           
            if (dragElement != null)
            {
                HandleDrop();
            }
            
            
        }
        previousMousePos = mousePos;
    }
    private void HandleDrop()
    {
        Ad currentAd = dragElement.GetComponent<Ad>();
        GameObject instantiatedAd = null;
       
        if (currentAd.GetTypeAd() == "Bad")
        {
            instantiatedAd = Instantiate(adPrefabs[0], dragElement.transform);
        } else if (currentAd.GetTypeAd() == "Good")
        {
            instantiatedAd = Instantiate(adPrefabs[1], dragElement.transform);
        } else if (currentAd.GetTypeAd() == "Glorious")
        {
            instantiatedAd = Instantiate(adPrefabs[2], dragElement.transform);
        } else if (currentAd.GetTypeAd() == "Horrible")
        {
            instantiatedAd = Instantiate(adPrefabs[3], dragElement.transform);
        }
        instantiatedAd.transform.SetParent(uiCanvas.transform, true);
        audioDropSFX.Play();
        dragElement.transform.position = currentAd.getDefaultPos();
        gameManager.ApplyAd(currentAd);
        AdType type = adtypes[WeightedRandom()];
        currentAd.SetAndRandomize(type);
        dragElement = null;
    }
    private void DragAd()
    {
        RectTransform element_rect = dragElement.GetComponent<RectTransform>();

        Vector2 drag_movement = mousePos - previousMousePos;

        element_rect.anchoredPosition = element_rect.anchoredPosition + drag_movement;
    }
    private void GetUIElementsClicked()
    {
        
        clickData.position = mousePos;
        clickResults.Clear();
        uiRaycaster.Raycast(clickData, clickResults);
        clickedElements.Clear();
        foreach (RaycastResult result in clickResults)
        {
            clickedElements.Add(result.gameObject);
        }
        if (clickedElements.Count > 0 && clickedElements[0].tag == "Ad")
        {
            dragging = true;
            dragElement = clickedElements[0];
            Ad ad = dragElement.GetComponent<Ad>();
           
        }
         
    }
    
    private int WeightedRandom()
    {
        int randomNum = Random.Range(0, 100);
        int firstTypeIndex = 0;
        int secondTypeIndex = 1;
        int thirdTypeIndex = 2;
        int fourthTypeIndex = 3;
        if (randomNum <= 10)
        {
            return fourthTypeIndex;
        } else if (randomNum > 15 && randomNum <= 30)
        {
            return thirdTypeIndex;
        } else if (randomNum > 30 && randomNum <= 70)
        {
            return firstTypeIndex;
        } else
        {
            return secondTypeIndex;
        }
    }
    private void AdInitialization()
    {
  
        foreach (GameObject slot in adSlots)
        {
            Ad adFromSlot = slot.GetComponent<Ad>();
            
            AdType type = adtypes[WeightedRandom()];
            adFromSlot.SetAndRandomize(type);
        }
    }
    private void AdRandomization()
    {
        GameObject randomSlot = adSlots[Random.Range(0, adSlots.Length)];
        AdType randomAdtype = adtypes[Random.Range(0, adtypes.Length)];
        Ad adFromSlot = randomSlot.GetComponent<Ad>();
        adFromSlot.SetAndRandomize(randomAdtype);
    }
}
