using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaIdioma : MonoBehaviour {

	void Awake () {
		Cargar();
	}

	public void Cargar(){
		string temp = "";

		switch (PlayerPrefs.GetString("idioma")){
			case "esp":
				temp = gameObject.name;
			break;

			case "eng":
				temp = gameObject.name+"_eng";
			break;
		}

		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(temp);
	}
}
