using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CargadorEscenas {

	public static void CargaEscena(string nombre){
		SceneManager.LoadScene(nombre);
	}

	public static void CargaEscenaAsync(string nombre){
		SceneManager.LoadSceneAsync(nombre);
	}
}
