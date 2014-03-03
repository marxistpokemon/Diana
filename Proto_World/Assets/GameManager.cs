using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager g;

	// Use this for initialization
	void Awake () {
		g = this;
	}
}
