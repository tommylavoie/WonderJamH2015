using UnityEngine;
using System.Collections;

public class vueTactic : MonoBehaviour {
	Vector3 pos;

	// Use this for initialization
	void Start () {
		pos = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.V)) {
			pos.x = 0f;
			pos.y = 50.3f;
			pos.z = 14.4f;
			this.gameObject.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
			this.gameObject.transform.position = pos;
		}
		if (Input.GetKeyUp (KeyCode.V)) {
			pos.x = 0f;
			pos.y = 13.49f;
			pos.z = -28.65f;
			this.gameObject.transform.rotation = Quaternion.AngleAxis(22, Vector3.right);
			this.gameObject.transform.position = pos;	

		}
	}
}
