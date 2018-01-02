using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaIdiomaTexto : MonoBehaviour {

	public string textoOriginal;
	public string textoEng;

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
				temp = textoEng;
			break;
		}

		//Debug.Log(temp);
		GetComponent<UnityEngine.UI.Text>().text = temp;
		spr.sprite = Resources.Load<Sprite>(temp);
	}
}
