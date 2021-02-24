using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Valve.VR;

public class ButtonTransitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    Button toClick;
    ColorBlock buttonColors;

    private void Start()
    {
        toClick = this.GetComponent<Button>();
        buttonColors = GetComponent<Button>().colors;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
     //   print("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // print("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      //  print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      //  print("Up");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
      //  toClick.onClick.Invoke();
        buttonColors.pressedColor = Color.green;
        toClick.colors = buttonColors;
        print("Clicked" + gameObject.name);
    }
}
