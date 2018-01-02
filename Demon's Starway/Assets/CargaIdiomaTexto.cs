using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaIdiomaTexto : MonoBehaviour {

	public string textoOriginal;
	public string textoEng;

	string spriteOriginal;

	void Awake () {
		//spriteOriginal = GetComponent<SpriteRenderer>().sprite.name;
		Cargar();
	}

	public void Cargar(){
		string temp = "";

		SpriteRenderer spr = GetComponent<SpriteRenderer>();

		switch (PlayerPrefs.GetString("idioma","esp")){
			case "esp":
				temp = textoOriginal;
			break;

			case "eng":
				temp = spriteOriginal+"_eng";
			break;
		}

		//Debug.Log(temp);

		spr.sprite = Resources.Load<Sprite>(temp);
	}
}
