using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoMovil : MonoBehaviour {

	public Control controlJugador;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		controlJugador.AplicarFuerzaSaltoMovil();
	}

	void OnMouseDrag(){
		controlJugador.AplicarFuerzaSaltoMovil();
	}
}
