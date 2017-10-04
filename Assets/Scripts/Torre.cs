using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour {

	public GameObject projetilPrefab;
	public float tempoDeRecarga = 1f;
	private float ultimoDisparo;
	[SerializeField] private float raioAlcance;

	// Use this for initialization
	void Update () {
		Inimigo alvo = EscolheAlvo ();

		if (alvo != null) {
			Atira (alvo);
		}
	}

	private void Atira(Inimigo inimigo){

		float tempoAtual = Time.time;

		if (tempoAtual > ultimoDisparo + tempoDeRecarga) {
			ultimoDisparo = tempoAtual;
			GameObject pontoDisparo = this.transform.Find ("CanhaoDaTorre/PontoDeDisparo").gameObject;
			Vector3 posisaoPontoDisparo = pontoDisparo.transform.position;
			GameObject projetilObject = Instantiate (projetilPrefab, posisaoPontoDisparo, Quaternion.identity);	
			projetilObject.GetComponent<Missil> ();
			Missil.DefineAlvo (inimigo);
		}
	}

	private Inimigo EscolheAlvo(){
		GameObject[] inimigos = GameObject.FindGameObjectsWithTag ("Inimigo");
		foreach (GameObject inimigo in inimigos) {
			if (EstaNoAlcance (inimigo)) {
				return inimigo.GetComponent<Inimigo> ();
			}
		}
		return null;
	}

	private bool EstaNoAlcance(GameObject inimigo){
		Vector3 posicaoTorre = this.transform.position;
		Vector3 posicaoTorrePlano = Vector3.ProjectOnPlane (posicaoTorre, Vector3.up);

		Vector3 posicaoInimigo = inimigo.transform.position;
		Vector3 posicaoInimigoPlano = Vector3.ProjectOnPlane (posicaoInimigo, Vector3.up);

		float distanciaInimigo = Vector3.Distance (posicaoTorrePlano, posicaoInimigoPlano);

		return distanciaInimigo <= raioAlcance;
	}
}
