using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour {

	[SerializeField] private int vida = 10;

	void Start () {
		NavMeshAgent agente = GetComponent <NavMeshAgent> ();
		GameObject fimDoCaminho = GameObject.Find ("FimDoCaminho");
		Vector3 posisaoFimDoCaminho = fimDoCaminho.transform.position;
		agente.SetDestination (posisaoFimDoCaminho);
	}

	public void RecebeDano(int pontosDano){
		vida -= pontosDano;

		if (vida <= 0) {
			Destroy (this.gameObject);
		}
	}
}
