using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class HighlightTextUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;
    public Color highlightColor;
    public Color standardColor;

    private void Start()
    {
        text = GetComponent<Text>();
        standardColor = text.color;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        text.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        text.color = standardColor;
    }
}
