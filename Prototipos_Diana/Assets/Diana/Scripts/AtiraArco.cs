using UnityEngine;
using System.Collections;

public class AtiraArco : MonoBehaviour {

	public Transform mira;
	public Transform projetil;
	public bool estaAtirando = false;

	private MoveCarinha movimento;

	// Use this for initialization
	void Start () {
		movimento = GetComponent<MoveCarinha>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1") && !estaAtirando){
			estaAtirando = true;
			mira.gameObject.SetActive(true);
		}

		if(Input.GetButtonDown("Fire1") && estaAtirando){
			mira.RotateAround(transform.position, transform.forward, 10f);
		}

		if(Input.GetButtonUp("Fire1") && estaAtirando){
			estaAtirando = false;
			Transform flecha = GameObject.Instantiate(
				projetil, 
				transform.position + new Vector3((int)movimento.olhar*0.6f, 1.5f, 0f), 
				Quaternion.identity
			) as Transform;
			flecha.LookAt(mira.position);
			flecha.rigidbody.AddForce(flecha.forward*20f, ForceMode.VelocityChange);
			mira.gameObject.SetActive(false);
		}
	
	}
}
