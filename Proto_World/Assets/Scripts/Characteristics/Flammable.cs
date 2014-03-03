using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Vulnerable))]
public class Flammable : BaseCharacteristic {

	public bool onFire = false;
	public float damagePerFrame;

	//public static float[] sizeModifier;

	void Update(){
		if(onFire){
			base.WO.vulnerable.health -= damagePerFrame;
		}
	}
}
