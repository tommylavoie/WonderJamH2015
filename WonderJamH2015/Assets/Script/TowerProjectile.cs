using UnityEngine;
using System.Collections;
using System;

public class TowerProjectile : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        gameObject.tag = "TowerProjectile";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag == "Enemy")
        {
            Debug.Log("Hey un enemie, tuons le :D");
			otherCollider.GetComponent<EnemyScript>().kill();
            Destroy(this);
        }
    }
}
