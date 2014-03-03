using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WorldObject))]
public abstract class BaseCharacteristic : MonoBehaviour {

	protected WorldObject worldObj;
	
	void Awake () {
		worldObj = GetComponent<WorldObject>();
	}
}
