using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvent : EventTrigger
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        CursorManager.instance.Click();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.instance.Default();
    }
}
