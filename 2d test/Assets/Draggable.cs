using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform originalParent = null;
	public Vector3 originalPosition;

	public void OnBeginDrag (PointerEventData eventData) {

		originalParent = this.transform.parent;
		originalPosition = this.transform.position;

		this.transform.SetParent( this.transform.parent.parent );

		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag (PointerEventData eventData) {

		this.transform.position = eventData.position;

	}

	public void OnEndDrag (PointerEventData eventData) {
		this.transform.SetParent( originalParent );

		if (!isValidZone(eventData.hovered)) {
			this.transform.position = originalPosition;
		}

		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	private bool isValidZone (List<GameObject> hovered) {
		List<string> validTagList = new List<string>();
		validTagList.Add("DropZone");
		validTagList.Add("Table");
		
		bool status = false;

		foreach (GameObject el in hovered){
			if (validTagList.Contains(el.tag)) {
				status = true;
				break;
			}
		}
		return status;
	}

}
