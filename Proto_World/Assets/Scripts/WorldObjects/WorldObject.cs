using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WorldSize {
	MEDIUM,
	SMALL,
	TINY,
	BIG,
	GIANT,
	HUGE
}

public abstract class WorldObject : MonoBehaviour {

	public int id;
	public WorldSize size;
	public bool LoadFromXML = false;

	//TOP Include all components here
	[HideInInspector] public Vulnerable vulnerable;
	[HideInInspector] public Flammable flammable;
	[HideInInspector] public Habitable habitable;
	[HideInInspector] public Portable portable;
	[HideInInspector] public Productive productive;
	[HideInInspector] public Edible edible;

	public void Start(){
		vulnerable = GetComponent<Vulnerable>();
		flammable = GetComponent<Flammable>();
		habitable = GetComponent<Habitable>();
		portable = GetComponent<Portable>();
		productive = GetComponent<Productive>();
		edible = GetComponent<Edible>();
	}

	public void Destroy(){
		Destroy(transform.gameObject);
	}

	public void OnMouseDown(){
		//FIXME test code
		// Debug.Log ("WObj: " + name);
		if(gTeste.g.cursor == "pickup"){
			if(portable != null) {
				//TODO pick up with Portable script
				Debug.Log ("Picked up: " + name);
				Destroy();
			}
			else {
				Debug.Log ("Cannot pick that up: " + name);
			}
		}
	}
}
