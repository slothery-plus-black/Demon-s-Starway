using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownRullete : MonoBehaviour {
	GameObject roullete;
	RoulletePos roulleteP;
	GameObject roulleteL;
	RoulletePos roulletePL;
	CMl_Script cMl_Script;

	ReproductorSonidos sonidos;

	// Use this for initialization
	void Start () {
		roullete = GameObject.Find ("Roullete");
		roulleteP = roullete.GetComponent<RoulletePos> ();
		roulleteL = GameObject.Find ("RuletaNiveles");
		roulletePL = roulleteL.GetComponent<RoulletePos> ();
		cMl_Script = GameObject.Find("CM_level").GetComponent<CMl_Script>();
		sonidos = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();
	}

	// Update is called once per frame
	void Update () {
	}

	void OnMouseUp(){
		transform.GetChild(0).gameObject.SetActive(false);
		sonidos.ReproducirSonidoRuleta();
		if(!cMl_Script.GetLevel()){
			print ("ButtoDownP");
			roulleteP.SetBoolDown ();
		}else{
			print ("ButtoDownPL");
			roulletePL.SetBoolDown ();
		}
		
	}

		void OnMouseDown(){
			transform.GetChild(0).gameObject.SetActive(true);
			sonidos.ReproducirSonidoRuleta();
	}

}