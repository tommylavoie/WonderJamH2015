using UnityEngine;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {
    public float radius = 0.5f;
	public List<string> path;

	// Use this for initialization
	void Start () {
		path = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		switch (collision.gameObject.name) {
			 
		}
	}
}
