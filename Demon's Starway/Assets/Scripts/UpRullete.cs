using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpRullete : MonoBehaviour {
	GameObject roullete;
	RoulletePos roulleteP;
	GameObject roulleteL;
	RoulletePos roulletePL;
	CMl_Script cMl_Script;
	ReproductorSonidos sonido;

	// Use this for initialization
	void Start () {
		roullete = GameObject.Find ("Roullete");
		roulleteP = roullete.GetComponent<RoulletePos> ();
		roulleteL = GameObject.Find ("RuletaNiveles");
		roulletePL = roulleteL.GetComponent<RoulletePos> ();
		cMl_Script = GameObject.Find("CM_level").GetComponent<CMl_Script>();
		sonido = GameObject.FindGameObjectWithTag("reproductor").GetComponent<ReproductorSonidos>();
	}

	// Update is called once per frame
	void Update () {
	}

	void OnMouseUp(){
		transform.GetChild(0).gameObject.SetActive(false);
		if(!cMl_Script.GetLevel()){
			//print ("ButtoDownP");
			roulleteP.SetBoolUp ();
		}else{
			//print ("ButtoDownPL");
			roulletePL.SetBoolUp ();
		}
		
	}

	void OnMouseDown(){
		transform.GetChild(0).gameObject.SetActive(true);
		sonido.ReproducirSonidoRuleta();
	}

}