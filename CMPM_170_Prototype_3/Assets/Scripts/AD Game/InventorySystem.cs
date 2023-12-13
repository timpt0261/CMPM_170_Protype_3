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
        Debug.Log(clickData);
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
                Ad currentAd = dragElement.GetComponent<Ad>();
                dragElement.transform.position = currentAd.getDefaultPos();
                
                gameManager.ApplyAd(currentAd);
                dragElement = null;
            }
            
            
        }
        previousMousePos = mousePos;
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
    private void AdInitialization()
    {
        int count = 0;
        foreach (GameObject slot in adSlots)
        {
            Debug.Log(count++);
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
