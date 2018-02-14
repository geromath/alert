﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter (PointerEventData eventData) {
	}

	public void OnPointerExit (PointerEventData eventData) {
	}
	
	public void OnDrop (PointerEventData eventData) {
		Debug.Log("OnDrop + " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.originalParent = this.transform;
		}
	}
}
