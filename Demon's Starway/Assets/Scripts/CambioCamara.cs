using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour {

	public Camera camara1, MainCamara;
	public GameObject vidas;
	public AngelCircular scriptAngel;
	public float CountdownFrom;
	public float velTransicion;

	public GameObject nombreNvl;
	
	// Use this for initialization
	void Start () {
		vidas.SetActive(false);
		camara1.enabled =true;
		MainCamara.enabled = false;
		scriptAngel = GameObject.Find("Camara_Tour").GetComponent<AngelCircular>();
	}
	
	// Update is called once per frame
	void Update () {
		float time = CountdownFrom - Time.timeSinceLevelLoad;
		if(time <=3f){
			scriptAngel.Stop();
			camara1.transform.LookAt(GameObject.Find("Bicho").transform.position);
			camara1.transform.position = Vector3.Lerp(camara1.transform.position, MainCamara.transform.position,Time.deltaTime * velTransicion);
			Destroy(nombreNvl);
		}

		if(time<=0f){
			vidas.SetActive(true);
			Destroy(camara1);
			MainCamara.enabled = true;
			Destroy(gameObject);
		}
	}
}
