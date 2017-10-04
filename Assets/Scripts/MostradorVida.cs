using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostradorVida : MonoBehaviour {

	private Text campoTexto;

	[SerializeField] private Jogador jogador;

	void Start () {
		campoTexto = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		campoTexto.text = "Vida: " + jogador.GetVida();
	}
}
