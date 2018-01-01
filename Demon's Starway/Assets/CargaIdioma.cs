using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaIdioma : MonoBehaviour {

	string spriteOriginal;

	void Awake () {
		spriteOriginal = GetComponent<SpriteRenderer>().sprite.name;
		Cargar();
	}

	public void Cargar(){
		string temp = "";

		SpriteRenderer spr = GetComponent<SpriteRenderer>();

		switch (PlayerPrefs.GetString("idioma")){
			case "esp":
				temp = spriteOriginal;
			break;

			case "eng":
				temp = spriteOriginal+"_eng";
			break;
		}

		//Debug.Log(temp);

		spr.sprite = Resources.Load<Sprite>(temp);
	}
}
