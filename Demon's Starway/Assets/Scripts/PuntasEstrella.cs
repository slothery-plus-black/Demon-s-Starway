using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntasEstrella {

	int puntasEstrella = 0;

	public void SumarPunta(){
		puntasEstrella++;
	}

	public int GetPuntas(){
		return puntasEstrella;
	}
}
