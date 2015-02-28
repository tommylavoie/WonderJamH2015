using UnityEngine;
using System.Collections;

public class tireTour : MonoBehaviour {
	public GameObject tour;
	GameObject projectile;
	public int forceHaut;
	public int forceDevant;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void tireCaliss(){
		tour.transform.localPosition = this.gameObject.transform.localPosition;
		tour.transform.localRotation = this.gameObject.transform.localRotation;
		Vector3 pos = tour.transform.position;
		pos.y += 10f;
		projectile = (GameObject)Instantiate(tour);
		projectile.rigidbody.AddRelativeForce (Vector3.up * forceHaut, ForceMode.Impulse);
		projectile.rigidbody.AddRelativeForce (Vector3.forward * forceDevant, ForceMode.Impulse);	
	}
}
