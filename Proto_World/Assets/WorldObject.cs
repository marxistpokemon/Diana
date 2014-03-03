using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldObject : MonoBehaviour {

	public new string name;
	public int id;
	public List<Component> chars;

	public void Destroy(){
		Destroy(transform.gameObject);
	}
}
