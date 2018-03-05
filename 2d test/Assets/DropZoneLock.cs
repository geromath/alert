using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropZoneLock : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public void Start()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop + " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.originalParent = this.transform;
            Destroy(d.gameObject);
        }
    }
}
