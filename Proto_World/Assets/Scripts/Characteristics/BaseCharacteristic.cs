using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(WorldObject))]
public abstract class BaseCharacteristic : MonoBehaviour {

	protected WorldObject WO;
	
	void Awake () {
		WO = GetComponent<WorldObject>();
	}
}
