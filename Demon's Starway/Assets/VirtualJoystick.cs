﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	//public bool camara = false;
	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;
	public bool salto = false;
	public Control controlJugador;

	private void Start(){
		if (!salto){
			bgImg = GetComponent<Image>();
			joystickImg = transform.GetChild(0).GetComponent<Image>();
		}
	}

	public virtual void OnDrag(PointerEventData ped){
		if (!salto){
			Vector2 pos;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,ped.position,ped.pressEventCamera,out pos)){
				pos.x = (pos.x/bgImg.rectTransform.sizeDelta.x);
				pos.y = (pos.y/bgImg.rectTransform.sizeDelta.y);

				inputVector = new Vector3(pos.x*2+1,0,pos.y*2-1);
				inputVector = (inputVector.magnitude > 1.0f)?inputVector.normalized:inputVector;

				//Move joystick
				joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x/3), inputVector.z*(bgImg.rectTransform.sizeDelta.y/3));
			}
		}else{
			controlJugador.AplicarFuerzaSaltoMovil();
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag(ped);
	}

	public virtual void OnPointerUp(PointerEventData ped){
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float Horizontal(){
		if (inputVector.x != 0){
			return inputVector.x;
		}else{
			return 0;
		}
	}

	public float Vertical(){
		if (inputVector.z != 0){
			return inputVector.z;
		}else{
			return 0;
		}
	}
}