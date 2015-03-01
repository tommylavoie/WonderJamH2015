using UnityEngine;
using System.Collections;

public class tireTour : MonoBehaviour {
	public GameObject tour1;
	public GameObject tour2;
	public GameObject chaise;
	public GameObject item;
	public GameObject table;
	GameObject projectile;
	public int forceHaut;
	public int forceDevant;
	System.Random random;
	// Use this for initialization
	void Start () {
		random = new System.Random();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void tireProjectile(int force){
		GameObject gameObject;
		int rand = random.Next(0,10);
		if(rand < 4)
			gameObject = tour1;
		else if(rand < 8)
			gameObject = tour2;
		else
			gameObject = chaise;
		gameObject.transform.localPosition = this.gameObject.transform.localPosition;
		gameObject.transform.localRotation = this.gameObject.transform.localRotation;
		Vector3 pos = gameObject.transform.position;
		pos.y += 5f;
		gameObject.transform.localPosition = pos;
		projectile = (GameObject)Instantiate(gameObject);
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
		pos.y += 5f;
		item.transform.localPosition = pos;
		item.transform.position = pos;
		projectile = (GameObject)Instantiate(item);
		projectile.rigidbody.AddRelativeForce (Vector3.up * (forceHaut	+(force/4)), ForceMode.Impulse);
		projectile.rigidbody.AddRelativeForce (Vector3.forward * (forceDevant+(force/4)), ForceMode.Impulse);
	}

	public void flipTable(int force)
	{
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		foreach(GameObject go in allObjects)
		if (go.activeInHierarchy)
		{
			if(go.tag.Equals ("Enemy"))
			{
				Destroy (go);
			}
			if(go.tag.Equals("Map") || go.tag.Equals ("Enemy") || go.name.Equals("F1"))
			{
				go.AddComponent<Rigidbody>();
				go.rigidbody.useGravity = true;
				go.rigidbody.mass = 1;
				go.rigidbody.AddRelativeForce (Vector3.up * (forceHaut	+(force/2)), ForceMode.Impulse);
				go.rigidbody.AddRelativeForce (Vector3.forward * (forceDevant+(force/2)), ForceMode.Impulse);
			}
		}

		table.rigidbody.AddRelativeForce (Vector3.up * (forceHaut	+(force/2)), ForceMode.Impulse);
		table.rigidbody.AddRelativeForce (Vector3.forward * (forceDevant+(force/2)), ForceMode.Impulse);
	}
}
