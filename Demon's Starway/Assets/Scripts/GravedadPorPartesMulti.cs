using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GravedadPorPartesMulti : NetworkBehaviour {
	
	List<GameObject> objects;
	public Vector3 direccion;
	public float fuerzaGravitatoria = 1f;

	GameObject jugadorLocal;

	// Use this for initialization
	void Start () {
		//Debug.Log(isLocalPlayer);
		//Debug.Log(isServer);
		
			

		/*GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

		foreach (GameObject g in players){
			Renderer rend = g.GetComponent<Renderer>();
			//Debug.Log(rend.material.color);
			if (rend.material.color.Equals(Color.red)){
				jugadorLocal = g;

				break;
			}
		}*/

		//if (isServer){
			objects = new List<GameObject> ();
		//}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		//if (isServer){
			if (objects.Count != 0){
				foreach (GameObject o in objects){
					Rigidbody r = o.GetComponent<Rigidbody> ();
					r.AddForce(direccion * fuerzaGravitatoria, ForceMode.Acceleration);
				}
			}
			//print(objects.Count);
		/*}else{
			Rigidbody jr = jugadorLocal.GetComponent<Rigidbody> ();
			jr.AddForce(direccion * fuerzaGravitatoria, ForceMode.Acceleration);
		}*/
		
	}

	void OnTriggerEnter (Collider col){
		/*if (col.gameObject.tag.Equals("Player")){
			Renderer rend = col.gameObject.GetComponent<Renderer>();
			if (rend.material.color.Equals(Color.red)){
				objects.Add(col.gameObject);
			}
		}else{
			if (!col.gameObject.tag.Equals("enemigo"))
			objects.Add (col.gameObject);
		}*/

		objects.Add(col.gameObject);
		
	}

	void OnTriggerExit (Collider col){
		/*if (isServer){
			objects.Remove (col.gameObject);
		}else{*/
			
		//Debug.Log(rend.material.color);
		/*if (col.gameObject.tag.Equals("Player")){
			Renderer rend = col.gameObject.GetComponent<Renderer>();
			if (rend.material.color.Equals(Color.red)){
				objects.Remove(col.gameObject);
			}
		}else{
			objects.Remove (col.gameObject);
		}*/
		

		objects.Remove (col.gameObject);
	}

}
