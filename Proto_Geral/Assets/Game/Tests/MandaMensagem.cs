using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class MandaMensagem : MonoBehaviour {
	public float jumpForce = 5f;
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			MessageKit<ShakeInfo>.post(Mensagens.Shake, new ShakeInfo(0.3f, ScreenShakeStrength.Weak));	
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			MessageKit<ShakeInfo>.post(Mensagens.Shake, new ShakeInfo(0.6f, ScreenShakeStrength.Medium));		
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			MessageKit<ShakeInfo>.post(Mensagens.Shake, new ShakeInfo(2f, ScreenShakeStrength.Strong));		
		}
		*/
		if(Input.GetButtonDown("Jump")){
			MessageKit<PlayerAction>.post(MsgType.PlayerAction, PlayerAction.Jump);
			rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
		}
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.CompareTag("Ground")){
			MessageKit<PlayerAction>.post(MsgType.PlayerAction, PlayerAction.FallToGround);
		}
		else {
			MessageKit<PlayerAction>.post(MsgType.PlayerAction, PlayerAction.Bump);
		}

	}
}
