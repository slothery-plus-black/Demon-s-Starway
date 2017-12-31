using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaLuz : MonoBehaviour {
	public float velTime = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(velTime, velTime,0);
	}
}
