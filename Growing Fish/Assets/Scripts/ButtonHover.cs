using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor = Color.gray;
    private Color originalColor;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = originalColor;
    }
}
