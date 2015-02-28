using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider otherCollider) 
	{
		if (otherCollider.tag == "Enemy")
		{
			((EnemyScript)otherCollider.GetComponent<EnemyScript>()).kill();
			Destroy(gameObject);
		}
	}
}
