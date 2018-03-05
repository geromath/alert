﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Text scoreText;
    private int score = 0;

    public void Start()
    {
        scoreText.text = score.ToString();
    }

    public void OnPointerEnter (PointerEventData eventData) {
	}

	public void OnPointerExit (PointerEventData eventData) {
	}
	
	public void OnDrop (PointerEventData eventData) {
		Debug.Log("OnDrop + " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
            d.originalParent = this.transform;
            score = int.Parse(scoreText.text) + 10;
            scoreText.text = score.ToString();
            Destroy(d.gameObject);
        }

	}
}
