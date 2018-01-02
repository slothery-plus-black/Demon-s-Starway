using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intruction_B : MonoBehaviour {

	public GameObject fondo;
	public Sprite spriteCambio;
	public Sprite spriteCambio_eng;
	SpriteRenderer r;
	// Use this for initialization
	void Start () {
		r = fondo.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
		if (PlayerPrefs.GetString("idioma","esp").Equals("esp")){
			r.sprite = spriteCambio;
		}else{
			r.sprite = spriteCambio_eng;
		}
		
	}

	void OnMouseUp(){
		transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
		//cambiar imagenes de instrucciones
	}
}
