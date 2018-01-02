using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class ReproductorSonidos : MonoBehaviour {
	AudioSource au;

	int ganadorMulti = -1;

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
			CambiarSonidoFondo(CargadorEscenas.CogerNombreEscenaActual());
			au.Play();
		}
		else{
			//GameObject[] repro =  GameObject.FindGameObjectsWithTag("reproductor");

			foreach (GameObject o in GameObject.FindGameObjectsWithTag("reproductor")){
				if (o != gameObject)
					o.GetComponent<ReproductorSonidos>().CambiarSonidoFondo(CargadorEscenas.CogerNombreEscenaActual());
			}
			Destroy(gameObject);
		}
	}

	void Start() {
		CambiarSonidoFondo(CargadorEscenas.CogerNombreEscenaActual());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CambiarSonidoOnOff(){
		switch(PlayerPrefs.GetString("sonido","on")){
			case "on":
				if (au.isPlaying)
					au.Stop();
				CambiarSonidoFondo(CargadorEscenas.CogerNombreEscenaActual());
				au.Play();
				break;
			case "off":
				au.Stop();
				//CambiarSonidoFondo(CargadorEscenas.CogerNombreEscenaActual());
				break;
		}
	}

	public bool HaySonido(){
		string temp = PlayerPrefs.GetString("sonido","on");

		return (temp.Equals("on"));
	}

	public void CambiarSonidoFondo(string nivel){
		if (HaySonido()){
			AudioClip antiguo = au.clip;
			switch (nivel){
				case "menu":
				case "lobbymultijugador":
				case "lobbypersonalizado":
					au.clip = sonidoMenu;
					break;
				case "level1":
				case "level2":
				case "level3":
				case "multi":
					au.clip = sonidoNivel;
					break;
			}
			if (au.clip != antiguo){
				au.Stop();
				au.Play();
			}
			
		}
	}

	public void ReproducirSonido(AudioClip clip){
		if (HaySonido())
			au.PlayOneShot(clip);
	}

	public void ReproducirSonidoSpawn(){
		if (HaySonido())
			au.PlayOneShot(sonidoSpawn);
	}

	public void ReproducirSonidoSalto(){
		if (HaySonido())
			au.PlayOneShot(sonidoSalto);
	}

	public void ReproducirPuntaEstrella(int pos){
		if (HaySonido())
			au.PlayOneShot(sonidoPuntaEstrella[pos]);
	}

	public void ReproducirSonidoSalida(){
		if (HaySonido())
			au.PlayOneShot(sonidoSalida);
	}

	public void ReproducirSonidoDanio(){
		if (HaySonido())
			au.PlayOneShot(sonidoDanio);
	}

	public void ReproducirSonidoMuerte(){
		if (HaySonido())
			au.PlayOneShot(sonidoMuerte);
	}

	public void ReproducirSonidoClick(int pos){
		if (HaySonido())
			au.PlayOneShot(sonidoClick[pos]);
	}

	public void ReproducirSonidoRuleta(){
		if (HaySonido())
			au.PlayOneShot(sonidoRuleta);
	}

	public void SetGanador(int n){
		ganadorMulti = n;
	}

	public int GetGanador(){
		return ganadorMulti;
	}
}
