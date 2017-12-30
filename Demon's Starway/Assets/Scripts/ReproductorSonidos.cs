using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class ReproductorSonidos : MonoBehaviour {
	AudioSource au;

	public AudioClip sonidoSpawn;
	public AudioClip sonidoSalto;
	public AudioClip[] sonidoPuntaEstrella;
	public AudioClip sonidoSalida;
	public AudioClip sonidoDanio;
	public AudioClip sonidoMuerte;

	public AudioClip sonidoMenu;
	public AudioClip[] sonidoClick;
	public AudioClip sonidoRuleta;
	public AudioClip sonidoNivel;

	// Use this for initialization
	void Awake () {
		if (GameObject.FindGameObjectsWithTag("reproductor").Length <= 1){
			au = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
		}
		else{
			Destroy(gameObject);
		}
	}

	void Start() {
		CambiarSonidoFondo(CargadorEscenas.CogerNombreEscenaActual());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CambiarSonidoFondo(string nivel){
		au.Stop();
		switch (nivel){
			case "menu":
				au.clip = sonidoMenu;
				break;
			case "level1":
			case "level2":
			case "level3":
				au.clip = sonidoNivel;
				break;
		}
		au.Play();
	}

	public void ReproducirSonido(AudioClip clip){
		au.PlayOneShot(clip);
	}

	public void ReproducirSonidoSpawn(){
		au.PlayOneShot(sonidoSpawn);
	}

	public void ReproducirSonidoSalto(){
		au.PlayOneShot(sonidoSalto);
	}

	public void ReproducirPuntaEstrella(int pos){
		au.PlayOneShot(sonidoPuntaEstrella[pos]);
	}

	public void ReproducirSonidoSalida(){
		au.PlayOneShot(sonidoSalida);
	}

	public void ReproducirSonidoDanio(){
		au.PlayOneShot(sonidoDanio);
	}

	public void ReproducirSonidoMuerte(){
		au.PlayOneShot(sonidoMuerte);
	}

	public void ReproducirSonidoClick(int pos){
		au.PlayOneShot(sonidoClick[pos]);
	}

	public void ReproducirSonidoRuleta(){
		au.PlayOneShot(sonidoRuleta);
	}
}
