using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class Mensagens {
	public const int Aumentar = 0;
	public const int Shake = 1;
}

public class OuveMensagem : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		MessageKit<float>.addObserver(Mensagens.Aumentar, Aumentar);
	}

	void Aumentar (float novaEscala) {
		transform.localScale = transform.localScale * novaEscala;
	}

	void OnDestroy () {
		MessageKit<float>.removeObserver (Mensagens.Aumentar, Aumentar);
	}
}
