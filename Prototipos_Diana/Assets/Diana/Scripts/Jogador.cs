using UnityEngine;
using System.Collections;

public enum Olhar {
	Direita = 1,
	Esquerda = -1
}

public enum Acao {
	Parado = 0,
	Andando = 1,
	Atirando = 2
}

public class Jogador : MonoBehaviour {

	public Acao acaoAtual;
	public Olhar olhar;


	// Use this for initialization
	void Start () {
		acaoAtual = Acao.Parado;

		// inicializa movimentos
		escala = transform.localScale;
		animacao = GetComponent<SkeletonAnimation>();
		animacao.state.SetAnimation(0, "Idle", true);
		animacao.timeScale = 0.5f;
		motor = GetComponent<CharacterMotor>();
		offsetMira = mira.position - transform.position;

		// carrega inventario inicial
		gJogo.g.inventario.CarregaItem(gJogo.g.inventario.todosItens.Itens.Find(item => item.nome == "Flecha"), 5);
		gJogo.g.inventario.municao = "Flecha";
	}

	void Update () {
		if(acaoAtual != Acao.Atirando){
			ControlaMovimento();
		}
		ControlaTiros();
		transform.localScale = new Vector3((int)olhar * escala.x, escala.y, escala.z);
	}

	#region Movimento

	public float velocidade;

	private Vector3 escala;
	private SkeletonAnimation animacao;
	private CharacterMotor motor;

	void ControlaMovimento(){
		if(Input.GetAxis("Horizontal") == 0){
			acaoAtual = Acao.Parado;
			animacao.state.SetAnimation(0, "Idle", true);
			animacao.timeScale = 0.5f;
		}
		else {
			acaoAtual = Acao.Andando;
			animacao.state.SetAnimation(0, "Run_3", true);
			animacao.timeScale = 1.5f;
			animacao.zSpacing = 0f;

			if(Input.GetAxis("Horizontal") > 0){
				olhar = Olhar.Direita;
			}
			else {
				olhar = Olhar.Esquerda;
			}
		}
	}

	#endregion

	#region Tiros

	public Transform projetil;
	public Transform mira;
	public float velocidadeMira;
	private Vector3 offsetMira;

	void ControlaTiros (){

		if(Input.GetButton("Atirar") && gJogo.g.inventario.ContaItem(gJogo.g.inventario.municao) <= 0){
			StartCoroutine(gJogo.g.MostraMsgJogadorCurta("no ammo!"));
		}

		// quando acabou de pressionar o botao de tiro
		if(Input.GetButtonDown("Atirar") && acaoAtual != Acao.Atirando && gJogo.g.inventario.ContaItem(gJogo.g.inventario.municao) > 0){
			acaoAtual = Acao.Atirando;
			animacao.state.SetAnimation(0, "Idle", true);
			motor.canControl = false;
			mira.gameObject.SetActive(true);

			if(olhar == Olhar.Direita) {
				mira.position = transform.position + new Vector3(offsetMira.x, offsetMira.y, 0);
			}
			else {
				mira.position = transform.position + new Vector3(-offsetMira.x, offsetMira.y, 0);
			}
		}

		// quando esta segurando o botao de tiro
		if(Input.GetButton("Atirar") && acaoAtual == Acao.Atirando){
			float novoAnguloMira = 0f;

			float anguloAnterior = 
				Mathf.Atan2(mira.position.y-transform.position.y, 
				            mira.position.x-transform.position.x) * 180 / Mathf.PI;


			if(anguloAnterior <= 90f && anguloAnterior >= -90f){
				olhar = Olhar.Direita;
			}
			if(anguloAnterior > 90f || anguloAnterior < -90f){
				olhar = Olhar.Esquerda;
			}

			if(Input.GetAxis("Vertical") > 0){
				novoAnguloMira += (olhar == Olhar.Direita)? 
					velocidadeMira : -velocidadeMira;
			}
			else if(Input.GetAxis("Vertical") < 0){
				novoAnguloMira += (olhar == Olhar.Esquerda)? 
					velocidadeMira : -velocidadeMira;
			}

			float anguloFinal = anguloAnterior + novoAnguloMira;

			if(olhar == Olhar.Direita){
				anguloFinal = Mathf.Clamp(
					anguloFinal, -90f + velocidadeMira*2,
				    90f - velocidadeMira*2);
			}
			if(olhar == Olhar.Esquerda){
				if(anguloFinal > -90f - velocidadeMira*2 && anguloFinal < 0)
					anguloFinal = -90f - velocidadeMira*2;
				else if(anguloFinal < 90f + velocidadeMira*2 && anguloFinal > 0)
					anguloFinal = 90f + velocidadeMira*2;
			}

			anguloFinal -= anguloAnterior;
			mira.RotateAround(transform.position, transform.forward, anguloFinal);
		}

		// quando solta o botao de tiro
		if(Input.GetButtonUp("Atirar") && acaoAtual == Acao.Atirando){
			acaoAtual = Acao.Parado;
			motor.canControl = true;
			if(gJogo.g.inventario.DescarregaItem(gJogo.g.inventario.BuscaItemCarregado(gJogo.g.inventario.municao))){
				Transform projetil = GameObject.Instantiate(
					Resources.Load<Transform>("Itens/"+gJogo.g.inventario.municao), 
					transform.position + new Vector3((int)olhar*0.6f, 1.5f, 0f), 
					Quaternion.identity
					) as Transform;
				projetil.GetComponent<ItemMundo>().info = gJogo.g.inventario.BuscaItemInfo(gJogo.g.inventario.municao);
				projetil.LookAt(mira.position);
				projetil.rigidbody.AddForce(projetil.forward*20f, ForceMode.VelocityChange);
			}
			else {
				StartCoroutine(gJogo.g.MostraMsgJogadorCurta("no ammo!"));
			}
			mira.gameObject.SetActive(false);
		}
	}
	#endregion


}
