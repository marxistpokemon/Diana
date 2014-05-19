using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class ShakeInfo {
	public string name;
	public float duration, intensity;

	public ShakeInfo (string pName, float pDuration, float pIntensity) {
		name = pName;
		duration = pDuration;
		intensity = pIntensity;
	}
}

public class ScreenShake : MonoBehaviour {
	public float quick, average, longer;
	public float weak, medium, strong;

	protected AbstractGoTween _tween;

	void Start () {
		MessageKit<ShakeInfo>.addObserver(Mensagens.Shake, Shake);
		MessageKit<PlayerAction>.addObserver(MsgType.PlayerAction, PlayerShakes);
	}

	void PlayerShakes (PlayerAction action) {
		print (action.ToString());
		float strength, duration = 0;
		switch (action) {
		case PlayerAction.Die :
			strength = strong;
			duration = longer;
			break;
		case PlayerAction.FallToGround :
			strength = weak;
			duration = quick;
			break;
		default: 
			strength = weak/2;
			duration = quick/2;
			break;
		}
		Shake (new ShakeInfo (action.ToString(), duration, strength));
	}


	private void Shake (ShakeInfo shake)
	{
		if( _tween != null )
		{
			_tween.complete();
			_tween.destroy();
			_tween = null;
		}
		_tween = Go.to( transform, shake.duration, 
		               new GoTweenConfig().shake( Vector3.one * shake.intensity, GoShakeType.Position ) );
	}
}
