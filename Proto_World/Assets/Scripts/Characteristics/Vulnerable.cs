using UnityEngine;
using System.Collections;

public class Vulnerable : BaseCharacteristic {

	public float health;

	public void Update(){
		if(health < 0) {
			base.WO.Destroy();
		}
	}
}
