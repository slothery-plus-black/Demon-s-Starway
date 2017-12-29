﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_B : MonoBehaviour {
	GameObject CM;
	CM_Script cM_Script;
	public float mov;

	void Awake(){
		CM = GameObject.Find("CentroDeMasas");
		cM_Script = CM.GetComponent<CM_Script>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		transform.GetChild(1).gameObject.SetActive(true);
	}

	void OnMouseUp(){
		transform.GetChild(1).gameObject.SetActive(false);
		cM_Script.SetBoolMov(mov);
	}

	void OnMouseOver(){
		transform.GetChild(0).gameObject.SetActive(true);
	}
	void OnMouseExit(){
		transform.GetChild(0).gameObject.SetActive(false);
	}
}