using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cara : MonoBehaviour {
	int caraActual = -1;
	Vector3 fuerzaEnCara = Vector3.zero;

	//0 cara superior
	/*Vector3 fuerzaCara0 = new Vector3(1f,0f,1f);
	//1 cara inferior
	Vector3 fuerzaCara1 = new Vector3(-1f,0f,-1f);
	//2 cara frente
	Vector3 fuerzaCara2 = new Vector3(1f,1f,0f);
	//3 cara atras
	Vector3 fuerzaCara3 = new Vector3(-1f,-1f,0f);
	//4 cara derecha
	Vector3 fuerzaCara4 = new Vector3(0f,1f,1f);
	//5 cara izquierda
	Vector3 fuerzaCara5 = new Vector3(0f,-1f,-1f);*/
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(fuerzaEnCara);
	}

	void CambiarCara(int cara){
		/*switch (cara){
			case 0:
			fuerzaEnCara = new Vector3
			break;
		}*/
		caraActual = cara;
	}

	void OnTriggerEnter(Collider col){
		switch (col.gameObject.name){
			case "y":
			case "-y":
			case "x":
			case "-x":
			case "z":
			case "-z":
				fuerzaEnCara = Vector3.zero;
				CaraPlaneta carap = col.GetComponent<CaraPlaneta>();
				switch(carap.caras[0]){
					case "x":
						fuerzaEnCara.x = carap.direccionEnCara.x;
					break;
					case "y":
						fuerzaEnCara.y = carap.direccionEnCara.y;
					break;
					case "z":
						fuerzaEnCara.z = carap.direccionEnCara.z;
					break;
				}
				switch(carap.caras[1]){
					case "x":
						fuerzaEnCara.x = carap.direccionEnCara.x;
					break;
					case "y":
						fuerzaEnCara.y = carap.direccionEnCara.y;
					break;
					case "z":
						fuerzaEnCara.z = carap.direccionEnCara.z;
					break;
				}
			break;
		}
	}
}
