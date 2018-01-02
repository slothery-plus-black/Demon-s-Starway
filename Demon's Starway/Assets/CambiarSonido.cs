using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarSonido : MonoBehaviour {

	public string sonido;
	public GameObject otro;
	Collider2D c, cOtro;
	SpriteRenderer r, rOtro;

	void Awake () {
		r= GetComponent<SpriteRenderer>();
		c = GetComponent<Collider2D>();
		cOtro = otro.GetComponent<Collider2D>();
		rOtro = otro.GetComponent<SpriteRenderer>();

		//Ocultar();
	}

	void Start(){
		Ocultar();
	}

	void OnMouseDown(){
		Cambio();
	}

	void Cambio(){

		PlayerPrefs.SetString("sonido",sonido);

		GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>().CambiarSonidoOnOff();
		
		Ocultar();
	}

	void Ocultar(){
		if (PlayerPrefs.GetString("sonido","on").Equals(sonido)){
			c.enabled = false;
			r.enabled = false;

			transform.GetChild(0).gameObject.SetActive(false);

			rOtro.enabled = true;
			cOtro.enabled = true;

			otro.transform.GetChild(0).gameObject.SetActive(true);
		}
		

		
	}
}
