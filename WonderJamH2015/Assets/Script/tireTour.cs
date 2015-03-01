using UnityEngine;
using System.Collections;

public class tireTour : MonoBehaviour {
	public GameObject tour;
	public GameObject item;
	GameObject projectile;
	public int forceHaut;
	public int forceDevant;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void tireProjectile(int force){
		tour.transform.localPosition = this.gameObject.transform.localPosition;
		tour.transform.localRotation = this.gameObject.transform.localRotation;
		Vector3 pos = tour.transform.position;
		pos.y += 10f;
		projectile = (GameObject)Instantiate(tour);
		projectile.rigidbody.AddRelativeForce (Vector3.up * (forceHaut	+(force/4)), ForceMode.Impulse);
		projectile.rigidbody.AddRelativeForce (Vector3.forward * (forceDevant+(force/4)), ForceMode.Impulse);	
	}

	public void tireItem(int force)
	{
		item.transform.localPosition = this.gameObject.transform.localPosition;
		item.transform.localRotation = this.gameObject.transform.localRotation;
		Vector3 pos = item.transform.position;
		pos.x -= 1.147f;
		pos.y += 0.422f;
		pos.z += 0.414f;
		item.transform.position = pos;
		projectile = (GameObject)Instantiate(item);
		projectile.rigidbody.AddRelativeForce (Vector3.up * (forceHaut	+(force/4)), ForceMode.Impulse);
		projectile.rigidbody.AddRelativeForce (Vector3.forward * (forceDevant+(force/4)), ForceMode.Impulse);
	}
}
