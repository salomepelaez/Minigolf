using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragListener : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Action<PointerEventData> onBeginDrag     = null;
    public Action<PointerEventData> onDrag          = null;
    public Action<PointerEventData> onEndDrag       = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(onBeginDrag != null)
        {
            onBeginDrag(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(onDrag != null)
        {
            onDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(onEndDrag != null)
        {
            onEndDrag(eventData);
        }
    }
}
