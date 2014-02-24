using UnityEngine;
using System.Collections;

public class SeguePeronagem : MonoBehaviour {

	public Transform alvo;
	Vector3 offset;
	public float suavizacao;

	// Use this for initialization
	void Start () {
		offset = transform.position - alvo.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(
			transform.position, 
			new Vector3(alvo.position.x, transform.position.y, alvo.position.z+offset.z), 
			Time.deltaTime*suavizacao);
	}
}
