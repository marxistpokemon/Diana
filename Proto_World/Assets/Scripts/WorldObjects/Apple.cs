using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Vulnerable))]
[RequireComponent(typeof(Flammable))]
[RequireComponent(typeof(Edible))]
[RequireComponent(typeof(Portable))]

public class Apple : WorldObject {

	public float timeInTree;

	public new void Start(){
		base.Start();
		rigidbody.useGravity = false;
		StartCoroutine("AppleFall");
	}

	public IEnumerator AppleFall() {
		yield return new WaitForSeconds(timeInTree);
		rigidbody.useGravity = true;
	}
}

