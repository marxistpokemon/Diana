using UnityEngine;
using System.Collections;

public class TriggerInteracao : MonoBehaviour {

	void OnTriggerEnter(Collider obj){
		if(obj.gameObject.CompareTag("Item")){
			Debug.Log ("enter:" + obj.name);
			gJogo.g.MostraMsgJogador("pegar " + obj.name);
		}
	}

	void OnTriggerStay(Collider obj){
		if(obj.gameObject.CompareTag("Item")){
			Debug.Log ("stay:" + obj.name);
		}
	}

	void OnTriggerExit(Collider obj){
		if(obj.gameObject.CompareTag("Item")){
			Debug.Log ("exit:" + obj.name);
			gJogo.g.EscondeMsgJogador();
		}
	}
}
