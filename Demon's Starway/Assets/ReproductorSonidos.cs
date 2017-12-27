using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class ReproductorSonidos : MonoBehaviour {
	AudioSource au;

	// Use this for initialization
	void Start () {
		au = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReproducirSonido(AudioClip clip){
		au.PlayOneShot(clip);
	}

	public void CambiarSonidoFondo(AudioClip clip){
		au.Stop();
		au.clip = clip;
		au.Play();
	}
}
