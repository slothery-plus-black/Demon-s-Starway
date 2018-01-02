using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intruction_B : MonoBehaviour {

	public GameObject object;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
	}

	void OnMouseUp(){
		transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
		//cambiar imagenes de instrucciones
	}
}
