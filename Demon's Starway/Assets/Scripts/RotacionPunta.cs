using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionPunta : MonoBehaviour {

	public float velocidad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0f,0f,velocidad * Time.deltaTime);
	}
}
