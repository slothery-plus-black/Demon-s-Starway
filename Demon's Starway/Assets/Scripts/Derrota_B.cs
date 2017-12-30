using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derrota_B : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		CargadorEscenas.CargaEscenaAsync("Menu");
	}
}
