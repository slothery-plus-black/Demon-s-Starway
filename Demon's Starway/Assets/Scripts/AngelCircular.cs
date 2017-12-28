using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelCircular : MonoBehaviour {

	public Transform puntoRotacion;
	private Vector3 puntoRotFinal;
	public float speed;
	public Vector3 direccion;

	// Use this for initialization
	void Start () {
		puntoRotFinal = puntoRotacion.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(puntoRotFinal, direccion,speed * Time.deltaTime);
	}
}
