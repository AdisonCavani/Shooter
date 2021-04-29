using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private RectTransform dragRectTransform;

    Vector2 upLeft = new Vector2(-584, 264);
    Vector2 upRigh = new Vector2(584, 264);
    Vector2 downLeft = new Vector2(-584, -264);
    Vector2 downRight = new Vector2(584, -264);

    public void OnDrag(PointerEventData eventData)
    {
        //if (dragRectTransform.anchoredPosition.x >= -584 && dragRectTransform.anchoredPosition.x <=)
        //{

        //}
        dragRectTransform.anchoredPosition += eventData.delta;
    }

    void Update()
    {
        Mathf.Clamp(dragRectTransform.anchoredPosition.x, -584, 584);
        Mathf.Clamp(dragRectTransform.anchoredPosition.y, -264, 264);
    }
}
