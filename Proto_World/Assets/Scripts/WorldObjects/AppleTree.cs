using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Vulnerable))]
[RequireComponent(typeof(Flammable))]
[RequireComponent(typeof(Productive))]

public class AppleTree : WorldObject {
	
	public new void Start(){
		base.Start();
		StartCoroutine(
			base.productive.Produce(
				base.productive.products[0])
			);
	}
}

