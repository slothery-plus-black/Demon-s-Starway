﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GravedadPorPartesMulti : NetworkBehaviour {
	
	List<GameObject> objects;
	public Vector3 direccion;
	public float fuerzaGravitatoria = 1f;

	// Use this for initialization
	void Start () {
		Debug.Log(isLocalPlayer);
		Debug.Log(isServer);
		objects = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (objects.Count != 0)
		foreach (GameObject o in objects){
			Rigidbody r = o.GetComponent<Rigidbody> ();
			r.AddForce(direccion * fuerzaGravitatoria, ForceMode.Acceleration);
		}
	}

	void OnTriggerEnter (Collider col){
		objects.Add (col.gameObject);
	}

	void OnTriggerExit (Collider col){
		objects.Remove (col.gameObject);
	}

}
