using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogo : MonoBehaviour {

	[SerializeField] private GameObject torrePrefab;
	[SerializeField] private GameObject gameOver;
	[SerializeField] private Jogador jogador;

	void Start(){
		gameOver.SetActive (false);
	}

	void Update(){

		if (JogoAcabou ()) {
			gameOver.SetActive (true);
		} else {
			if (ClicouBotaoPrimario ()) {
				ControiTorre ();
			}
		}
	}

	private bool JogoAcabou(){
		return !jogador.EstaVivo ();
	}

	private bool ClicouBotaoPrimario(){
		return Input.GetMouseButtonDown (0);
	}

	public void RecomecaJogo(){
		//Application.LoadLevel (Application.loadedLevel);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);  
	}

	private void ControiTorre (){
		Vector3 posicaoClick = Input.mousePosition;
		RaycastHit elementoAtingido = DisparaRaioDaCamera (posicaoClick);

		if (elementoAtingido.collider != null) {
			Vector3 posicaoCriacaoTorre = elementoAtingido.point;
			Instantiate (torrePrefab, posicaoCriacaoTorre, Quaternion.identity);
		}
	}

	private RaycastHit DisparaRaioDaCamera(Vector3 pontoInicial){
		Ray raio = Camera.main.ScreenPointToRay (pontoInicial);
		RaycastHit elementoAtingido;
		float comprimentoMaximoRaio = 100f;
		Physics.Raycast (raio, out elementoAtingido, comprimentoMaximoRaio);

		return elementoAtingido;
	}
}
