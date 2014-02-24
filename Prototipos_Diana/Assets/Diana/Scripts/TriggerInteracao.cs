using UnityEngine;
using System.Collections;

public class TriggerInteracao : MonoBehaviour {

	void OnTriggerEnter(Collider obj){
		if(obj.gameObject.CompareTag("Item")){
			gJogo.g.MostraMsgJogador("pegar " + obj.GetComponent<ItemMundo>().info.nome.ToLower());
		}
	}

	void OnTriggerStay(Collider obj){
		if(obj.gameObject.CompareTag("Item")){
			if(Input.GetButtonDown("Usar")){
				gJogo.g.inventario.CarregaItem(obj.GetComponent<ItemMundo>().info, 1);
				Destroy(obj.gameObject);
				gJogo.g.EscondeMsgJogador();
			}
		}
	}

	void OnTriggerExit(Collider obj){
		if(obj.gameObject.CompareTag("Item")){
			Debug.Log ("exit:" + obj.name);
			gJogo.g.EscondeMsgJogador();
		}
	}
}
