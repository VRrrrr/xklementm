using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Valve.VR;

public class Transitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{

    private void Start()
    {
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Up");
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        Destroy(gameObject);
        Debug.Log(name);
        
        
    }
 }
