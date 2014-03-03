using UnityEngine;
using System.Collections;

public class gTeste : MonoBehaviour {

	public static gTeste g;

	public Transform target;
	public string cursor;

	// test GUI formatting
	public Vector2 btnSize;

	void Awake(){
		g = this;
	}

	void Update () {
	
		if(Input.GetKeyDown(KeyCode.R)){
			target.GetComponent<Vulnerable>().health -= 1;
		}
	}

	// testing GUI
	void OnGUI(){
		if(GUI.Button(new Rect(0,0, btnSize.x, btnSize.y), "Fire damage")){
			cursor = "fire";
		}

		if(GUI.Button(new Rect(btnSize.x+20,0, btnSize.x, btnSize.y), "Pick up")){
			cursor = "pickup";
		}
	}
}
