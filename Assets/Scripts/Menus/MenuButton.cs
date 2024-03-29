using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public TextMeshProUGUI btnText;
    public Color hoverColor;
    public Color normalColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        btnText.color = hoverColor;
        Debug.Log("A");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btnText.color = normalColor; 
    }
}
