using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

	public Transform planeta;

	Rigidbody r;
	//public GameObject planeta;
	public float fuerza = 0.1f;
	Camera cam;

	List<Vector3> movH = new List<Vector3>();
	List<Vector3> movV = new List<Vector3>();
	//Vector3 movHorizontal = Vector3.zero;
	//Vector3 movVertical = Vector3.zero;

	bool enSuelo = false;
	//Lista de cuadrados para ver a donde mira

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//gameObject.transform.LookAt (planeta.transform.position);

		if (Input.GetKey (KeyCode.A)) {
			//r.AddForce (-cam.transform.right * fuerza, ForceMode.Impulse);
			//r.AddForce(-movHorizontal * fuerza, ForceMode.Impulse);
			r.AddForce(-movH[0] * fuerza, ForceMode.Impulse);
		}

		if (Input.GetKey (KeyCode.D)) {
			//r.AddForce (cam.transform.right * fuerza, ForceMode.Impulse);
			//r.AddForce(movHorizontal * fuerza, ForceMode.Impulse);
			r.AddForce(movH[0] * fuerza, ForceMode.Impulse);
		}

		if (Input.GetKey (KeyCode.W)) {
			//r.AddForce (cam.transform.up * fuerza, ForceMode.Impulse);
			r.AddForce(movV[0] * fuerza, ForceMode.Impulse);
		}

		if (Input.GetKey (KeyCode.S)) {
			//r.AddForce (-cam.transform.up * fuerza, ForceMode.Impulse);
			r.AddForce(-movV[0] * fuerza, ForceMode.Impulse);
		}

		if (Input.GetKey (KeyCode.Space)) {

			//r.AddForce (-cam.transform.up * fuerza, ForceMode.Impulse);
		}

		if (movH.Count>0){
		Debug.Log(movH[0]);
		Debug.Log(movV[0]);}
	}

	void OnCollission(Collision other){
		if (other.gameObject.name.Equals("planeta")){
			enSuelo = true;
		}
	}

	void OnCollissionExit(Collision other){
		if (other.gameObject.name.Equals("planeta")){
			enSuelo = false;
		}
	}

	void OnTriggerEnter(Collider other){
		switch (other.gameObject.name){
			case "x":
				//movHorizontal = planeta.transform.forward;
				movH.Add(planeta.transform.forward);
				movV.Add(planeta.transform.up);
				//movVertical = planeta.transform.up;
			break;
			case "-x":
				/*movHorizontal = -planeta.transform.forward;
				movVertical = planeta.transform.up;*/
				movH.Add(-planeta.transform.forward);
				movV.Add(planeta.transform.up);
			break;

			case "y":
				//movHorizontal = planeta.transform.right;
				//movVertical = planeta.transform.forward;
				movH.Add(cam.transform.right);
				Vector3 a = cam.transform.up + cam.transform.forward;
				//a.y = 0;
				movV.Add(a.normalized);
			break;
			case "-y":
				//movHorizontal = planeta.transform.right;
				//movVertical = -planeta.transform.forward;
				movH.Add(cam.transform.right);
				Vector3 a2 = cam.transform.up + cam.transform.forward;
				//a2.y = 0;
				movV.Add(-a2.normalized);
			break;

			case "z":
				//movHorizontal = -planeta.transform.right;
				//movVertical = planeta.transform.up;
				movH.Add(-planeta.transform.right);
				movV.Add(planeta.transform.up);
			break;
			case "-z":
				//movHorizontal = planeta.transform.right;
				//movVertical = planeta.transform.up;
				movH.Add(planeta.transform.right);
				movV.Add(planeta.transform.up);
			break;
		}
	}

	void OnTriggerStay(Collider other){
		switch (other.gameObject.name){
			case "y":
				//movHorizontal = planeta.transform.right;
				//movVertical = planeta.transform.forward;
				movH[0] = (cam.transform.right);
				Vector3 a = cam.transform.up + cam.transform.forward;
				//a.y = 0;
				movV[0] = (a.normalized);
			break;
			case "-y":
				//movHorizontal = planeta.transform.right;
				//movVertical = -planeta.transform.forward;
				movH[0] = (cam.transform.right);
				Vector3 a2 = cam.transform.up + cam.transform.forward;
				//a.y = 0;
				movV[0] = (a2.normalized);
			break;
		}
	}

	void OnTriggerExit(Collider other){
		switch (other.gameObject.name){
			case "x":
				//movHorizontal = planeta.transform.forward;
				movH.RemoveAt(0);
				movV.RemoveAt(0);
				//movVertical = planeta.transform.up;
			break;
			case "-x":
				/*movHorizontal = -planeta.transform.forward;
				movVertical = planeta.transform.up;*/
				movH.RemoveAt(0);
				movV.RemoveAt(0);
			break;

			case "y":
				//movHorizontal = planeta.transform.right;
				//movVertical = planeta.transform.forward;
				movH.RemoveAt(0);
				movV.RemoveAt(0);
			break;
			case "-y":
				//movHorizontal = planeta.transform.right;
				//movVertical = -planeta.transform.forward;
				movH.RemoveAt(0);
				movV.RemoveAt(0);
			break;

			case "z":
				//movHorizontal = -planeta.transform.right;
				//movVertical = planeta.transform.up;
				movH.RemoveAt(0);
				movV.RemoveAt(0);
			break;
			case "-z":
				//movHorizontal = planeta.transform.right;
				//movVertical = planeta.transform.up;
				movH.RemoveAt(0);
				movV.RemoveAt(0);
			break;
		}
	}
}
