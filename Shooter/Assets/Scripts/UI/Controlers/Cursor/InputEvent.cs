using UnityEngine;
using UnityEngine.EventSystems;

public class InputEvent : EventTrigger
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        CursorManager.instance.Edit();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.instance.Default();
    }
}
