using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CargadorEscenas {

	//Nivel 0 = menu, 1 level1...
	public static void CargaEscena(string nombre){

		GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>().CambiarSonidoFondo(nombre.ToLower());

		SceneManager.LoadScene(nombre);
	}

	public static void CargaEscenaAsync(string nombre){
		GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>().CambiarSonidoFondo(nombre.ToLower());

		SceneManager.LoadSceneAsync(nombre);
	}

	public static string CogerNombreEscenaActual(){
		return SceneManager.GetActiveScene().name.ToLower();
	}

	public static void CargarSiguienteNivel(string nombre){
		switch(nombre.ToLower()){
			case "level1":
				CargadorEscenas.CargaEscenaAsync("level2");
				break;
			case "level2":
				CargadorEscenas.CargaEscenaAsync("level3");
				break;
			case "level3":
				CargadorEscenas.CargaEscenaAsync("menu");
				break;
		}
	}
}
