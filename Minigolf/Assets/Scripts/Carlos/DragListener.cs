using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragListener : MonoBehaviour
{
    public Action<PointerEventData> onBeginDrag     = null;
    public Action<PointerEventData> onDrag          = null;
    public Action<PointerEventData> onEndDrag       = null;

    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    public void OnDrag(PointerEventData eventData)
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
