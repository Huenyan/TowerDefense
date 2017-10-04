using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missil : MonoBehaviour {

	[SerializeField] private float velocidade = 10;
	private static Inimigo alvo;
	[SerializeField] private int pontosDano = 2;

	void Start () {
		autoDestroi (4);
	}

	void Update () {
		Anda ();
		AlteraDirecao ();
	}

	private void Anda(){
		Vector3 posisaoAtual = transform.position;
		Vector3 deslocamento = transform.forward * Time.deltaTime * velocidade;
		transform.position = posisaoAtual + deslocamento;
	}

	private void AlteraDirecao(){
		if (alvo != null){
			Vector3 posicaoAtual = transform.position;
			Vector3 posicaoAlvo = alvo.transform.position;
			Vector3 direcaoAlvo = posicaoAlvo - posicaoAtual;
			transform.rotation = Quaternion.LookRotation (direcaoAlvo);
		} else {
			Destroy (this.gameObject);
		}
	}

	private void autoDestroi(float segundos){
		Destroy (this.gameObject, segundos);
	}

	void OnTriggerEnter (Collider elementoColidido){
		if (elementoColidido.CompareTag ("Inimigo")) {
			Destroy (this.gameObject);

			Inimigo inimigo = elementoColidido.GetComponent<Inimigo> ();
			inimigo.RecebeDano (pontosDano);

		}
	}

	public static void DefineAlvo (Inimigo inimigo){
		alvo = inimigo;
	}
}
