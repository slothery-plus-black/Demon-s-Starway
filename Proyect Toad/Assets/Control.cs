using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

	Rigidbody r;
	public GameObject planeta;
	public float fuerza = 0.1f;
	//Lista de cuadrados para ver a donde mira

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.LookAt (planeta.transform.position);

		if (Input.GetKey (KeyCode.A)) {
			//transform.position += new Vector3 (-1*Time.deltaTime, 0, 0);
			r.AddForce (new Vector3 (-fuerza, 0, 0), ForceMode.Impulse);
		}

		if (Input.GetKey (KeyCode.D)) {
			//transform.position += new Vector3 (1*Time.deltaTime, 0, 0);
			r.AddForce (new Vector3 (fuerza, 0, 0), ForceMode.Impulse);
		}

		if (Input.GetKey (KeyCode.W)) {

			r.AddForce (new Vector3 (0, 0, fuerza), ForceMode.Impulse);
		}

		if (Input.GetKey (KeyCode.S)) {

			r.AddForce (new Vector3 (0, 0, -fuerza), ForceMode.Impulse);
		}
	}
}
