using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaEscena : MonoBehaviour {

	//public string escena;
	public GameObject ruleta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		float rotZ = ruleta.transform.rotation.z;
		
		if (rotZ < 0.2f){
			CargadorEscenas.CargaEscena("Level1");
		}
		
		if (rotZ < 0.3f && rotZ > 0.2f){
			CargadorEscenas.CargaEscena("Level2");
		}

		if (rotZ < 0.6f && rotZ > 0.3f){
			CargadorEscenas.CargaEscena("Level3");
		}
	}
}
