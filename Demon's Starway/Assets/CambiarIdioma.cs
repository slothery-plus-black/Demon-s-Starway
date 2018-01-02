using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarIdioma : MonoBehaviour {

	int numIdiomas = 2;
	//string[] idiomas = new string[] {"esp","eng"};
	int n = 0;

	// Use this for initialization
	void Awake () {
		switch (PlayerPrefs.GetString("idioma","esp")){
			case "esp":
				n = 0;
			break;

			case "eng":
				n = 1;
			break;
		}
	}

	void OnMouseDown(){
		n++;
		Cambio();
	}

	void Cambio(){
		if (n >= numIdiomas){
			n = 0;
		}

		switch (n){
			case 0:
				PlayerPrefs.SetString("idioma","esp");
		
			break;

			case 1:
				PlayerPrefs.SetString("idioma","eng");
			break;
		}

		PlayerPrefs.Save();

		foreach (GameObject o in GameObject.FindGameObjectsWithTag("idioma")){
			o.GetComponent<CargaIdioma>().Cargar();
		}
	}
}
