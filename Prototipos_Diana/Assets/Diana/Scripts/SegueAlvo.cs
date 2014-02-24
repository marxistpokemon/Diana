using UnityEngine;
using System.Collections;

public class SegueAlvo : MonoBehaviour {
	public Transform alvo;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - alvo.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = alvo.position + offset;
	}
}
