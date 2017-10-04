using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour {

	[SerializeField] private int vida;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetVida(){
		return vida;
	}

	public void PerdeVida(){
		if (EstaVivo ()) {
			vida--;
		}
	}

	public bool EstaVivo(){
		return vida > 0;
	}
}
