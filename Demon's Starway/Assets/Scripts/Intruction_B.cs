using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intruction_B : MonoBehaviour {

	public GameObject fondo;
	public Sprite spriteCambio;
	public Sprite spriteCambio_eng;

	public int texto;
	public GameObject[] textos;

	public string textCambio;
	public string textCambio_eng;
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
			MostrarTexto(textCambio);
		}else{
			r.sprite = spriteCambio_eng;
			MostrarTexto(textCambio_eng);
		}
		
	}

	void OnMouseUp(){
		transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
		//cambiar imagenes de instrucciones
	}

	void MostrarTexto(string t){
		for (int i = 0;i<textos.Length;i++){
			GameObject o = textos[i];
			if (i == texto){
				textos[i].SetActive(true);
				textos[i].GetComponent<UnityEngine.UI.Text>().text = t;
			}else{
				textos[i].SetActive(false);
			}
		}
	}
}
