using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarSonido : MonoBehaviour {

	void OnMouseDown(){
		switch (PlayerPrefs.GetString("sonido","on")){
			case "on":
				PlayerPrefs.SetString("sonido","off");
			break;

			case "off":
				PlayerPrefs.SetString("sonido","on");
			break;
		}

		GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>().CambiarSonidoOnOff();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
