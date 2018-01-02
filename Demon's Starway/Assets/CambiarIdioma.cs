using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarIdioma : MonoBehaviour {

	public string idioma;
	public GameObject otro;
	Collider2D c, cOtro;
	SpriteRenderer r, rOtro;

	//int numIdiomas = 2;
	//string[] idiomas = new string[] {"esp","eng"};
	//int n = 0;

	// Use this for initialization
	void Awake () {
		r= GetComponent<SpriteRenderer>();
		c = GetComponent<Collider2D>();
		cOtro = otro.GetComponent<Collider2D>();
		rOtro = otro.GetComponent<SpriteRenderer>();

		Ocultar();
	}

	void OnMouseDown(){
		//n++;
		Cambio();
	}

	void Cambio(){

		PlayerPrefs.SetString("idioma",idioma);

		PlayerPrefs.Save();

		foreach (GameObject o in GameObject.FindGameObjectsWithTag("idioma")){
			o.GetComponent<CargaIdioma>().Cargar();
		}

		foreach (GameObject o in GameObject.FindGameObjectsWithTag("idioma_texto")){
			o.GetComponent<CargaIdiomaTexto>().Cargar();
		}

		Ocultar();
	}

	void Ocultar(){
		//print(idiomacargado);
		if (PlayerPrefs.GetString("idioma","esp").Equals(idioma)){
			c.enabled = false;
			r.enabled = false;

			transform.GetChild(0).gameObject.SetActive(false);

			rOtro.enabled = true;
			cOtro.enabled = true;

			otro.transform.GetChild(0).gameObject.SetActive(true);
		}
	}
}
