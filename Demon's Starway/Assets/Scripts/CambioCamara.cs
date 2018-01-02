using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour {

public Camera camera1;
public Camera MainCamera;
public float CountdownFrom;
public GameObject vidas;
public float velTransicion; 
public AngelCircular script;

 void Start () {
 vidas.SetActive(false);
 camera1.enabled = true;
 MainCamera.enabled = false;
 script = GameObject.Find("Camara_Tour").GetComponent<AngelCircular>();

 }

 void Update() {
        float time = CountdownFrom - Time.timeSinceLevelLoad;
		if (time <= 3f){
			script.Stop();
			camera1.transform.position = Vector3.Lerp(camera1.transform.position, MainCamera.transform.position,Time.deltaTime * velTransicion);
		}
        if(time<=0f) {
		Switch();
        }
 }
	void Switch(){
	 vidas.SetActive(true);
		 camera1.enabled = false;
    	 MainCamera.enabled = true; 
	}	
}
