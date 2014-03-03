using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Vulnerable))]
[RequireComponent(typeof(Flammable))]
[RequireComponent(typeof(Habitable))]

public class Cabin : WorldObject {

	public new void Start(){
		base.Start();
	}


}
