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
			transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
		}
		
		if (rotZ < 0.3f && rotZ > 0.2f){
			transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
		}

		if (rotZ < 0.6f && rotZ > 0.3f){
			transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
		}
	}

	void OnMouseUp(){
		float rotZ = ruleta.transform.rotation.z;
		
		if (rotZ < 0.2f){
			transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
			CargadorEscenas.CargaEscena("Level1");
		}
		
		if (rotZ < 0.3f && rotZ > 0.2f){
			transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(false);
			CargadorEscenas.CargaEscena("Level2");
		}

		if (rotZ < 0.6f && rotZ > 0.3f){
			transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(false);
			CargadorEscenas.CargaEscena("Level3");
		}
	}
}
