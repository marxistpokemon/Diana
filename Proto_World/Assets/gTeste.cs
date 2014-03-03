using UnityEngine;
using System.Collections;

public class gTeste : MonoBehaviour {

	public Transform alvo;
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.R)){
			alvo.GetComponent<Vulnerable>().health -= 1;
		}
	}
}
