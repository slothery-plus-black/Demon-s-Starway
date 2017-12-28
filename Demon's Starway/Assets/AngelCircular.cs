using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelCircular : MonoBehaviour {

	public Transform puntoRotacion;
	public float speed;
	public Vector3 direccion;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(puntoRotacion.position, direccion,speed * Time.deltaTime);
	}
}
