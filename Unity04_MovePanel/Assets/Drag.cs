using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(rectTransform.anchoredPosition);

    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling();
        rectTransform.position = eventData.position;
        Debug.Log(rectTransform.anchoredPosition);



    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {

    }
}
