using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadCircular : MonoBehaviour {

	public List<GameObject> objects;
	public GameObject planet;

	public float gravitationalPull;

	void FixedUpdate() {
		foreach (GameObject o in objects) {
			Rigidbody r = o.GetComponent<Rigidbody> ();
			r.AddForce((planet.transform.position - o.transform.position).normalized * gravitationalPull);
		}
	}
}
