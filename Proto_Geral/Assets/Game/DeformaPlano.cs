using UnityEngine;
using System.Collections;

public class DeformaPlano : MonoBehaviour {
	PerlinNoise perlin;
	public int octaves;
	public float frequency, amplitude;
	
	// Use this for initialization
	void Start () {
		Deform ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Alpha0)){
			Deform ();
		}
		
	}

	void Deform () {
		perlin = new PerlinNoise(Random.Range(0, Mathf.RoundToInt(Mathf.Infinity)));
		
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		for(int i = 0; i < vertices.Length; i++) {
			if (vertices[i].y >= transform.position.y - 0.2f) { // if top face vertex
				float height = perlin.FractalNoise2D(vertices[i].x, vertices[i].z, octaves, frequency, amplitude); 
				if (height < 0) height = vertices[i].y;
				vertices[i].y = height;
			}
		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		
		MeshCollider mCollider = GetComponent<MeshCollider>();
		mCollider.sharedMesh = mesh;
	}

}

