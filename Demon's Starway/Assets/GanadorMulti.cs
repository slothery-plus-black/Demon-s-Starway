using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GanadorMulti : MonoBehaviour {

	Text texto;

	// Use this for initialization
	void Start () {
		texto = GetComponent<Text>();

		ReproductorSonidos reproductor = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();

		if (reproductor.GetGanador() == 0 || reproductor.GetGanador() == -1){
			texto.text = "Looser marica";
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
