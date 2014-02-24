using UnityEngine;
using System.Collections;

public class gJogo : MonoBehaviour {

	public static gJogo g;

	public gInventario inventario;
	public Transform objMsgTL;
	private GUIText msgTL;

	public Transform objMsgJogador;
	private TextMesh msgJogador;

	// Use this for initialization
	void Awake () {
		g = this;

		// incializa msgs
		msgTL = objMsgTL.GetComponent<GUIText>();
		msgJogador = objMsgJogador.GetComponent<TextMesh>();
		msgJogador.renderer.enabled = false;
	}

	void Update(){
		msgTL.text = g.inventario.ContaItem(g.inventario.municao) + " flechas";
	}

	public IEnumerator MostraMsgJogadorCurta(string texto){
		msgJogador.text = texto;
		msgJogador.renderer.enabled = true;
		yield return new WaitForSeconds(1f);
		msgJogador.renderer.enabled = false;
	}

	public void MostraMsgJogador(string texto){
		msgJogador.text = texto;
		msgJogador.renderer.enabled = true;
	}

	public void EscondeMsgJogador(){
		msgJogador.renderer.enabled = false;
	}
}
