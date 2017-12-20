using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadPorPartes : MonoBehaviour {
	
	List<GameObject> objects;
	public Vector3 direccion;
	public float fuerzaGravitatoria = 1f;

	// Use this for initialization
	void Start () {
		objects = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (objects.Count != 0)
		foreach (GameObject o in objects){
			Rigidbody r = o.GetComponent<Rigidbody> ();
			r.AddForce(direccion.normalized * fuerzaGravitatoria * r.mass);
		}
	}


	void OnTriggerEnter (Collider col){
		objects.Add (col.gameObject);
	}

	void OnTriggerExit (Collider col){
		objects.Remove (col.gameObject);
	}

}
