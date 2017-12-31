using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour {

public Camera camera1;
public Camera MainCamera;
public float CountdownFrom;

 void Start () {
 
 camera1.enabled = true;
 MainCamera.enabled = false;

 }

 void Update() {
        float time = CountdownFrom - Time.timeSinceLevelLoad;
 
        if(time<=0f) {
            Switch();
        }
    }
 
 void Switch(){
 
     camera1.enabled = false;
     MainCamera.enabled = true;
     
 }
}
