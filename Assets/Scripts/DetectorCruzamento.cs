using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorCruzamento : MonoBehaviour {

	[SerializeField] private Jogador jogador;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider collider){
		if (collider.CompareTag ("Inimigo")) {
			Destroy (collider.gameObject);
			jogador.PerdeVida ();
		}
	}
}
