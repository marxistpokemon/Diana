using UnityEngine;
using System.Collections;

public class MoveCarinha : MonoBehaviour {

	Vector3 escala;
	SkeletonAnimation animacao;
	public float velocidade;
	public float velocidadeAngular;

	public Olhar olhar;

	// Use this for initialization
	void Start () {
		escala = transform.localScale;
		animacao = GetComponent<SkeletonAnimation>();
		animacao.state.SetAnimation(0, "Idle", true);
		animacao.timeScale = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {



	}
}
