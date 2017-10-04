using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour {

	[SerializeField] private GameObject inimigo;
	private float tempoCriacao = 2f;
	private float ultimaGeracao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GeraInimigo ();
	}

	private void GeraInimigo(){

		float tempoAtual = Time.time;

		if (tempoAtual > ultimaGeracao + tempoCriacao) {
			ultimaGeracao = tempoAtual;
			Vector3 posicaoGerador = this.transform.position;
			Instantiate (inimigo, posicaoGerador, Quaternion.identity);
            if(tempoCriacao >= 0.5f) tempoCriacao -= 0.08f;
        }
	}
}
