using UnityEngine;
using System.Collections;

public class vueTactic : MonoBehaviour {
	Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.V)) {
			pos.x = 10;
			this.gameObject.transform.position = pos;
			Debug.Log(this.gameObject.transform.position);
		}
		if (Input.GetKeyUp (KeyCode.V)) {
			
		}
	}
}
