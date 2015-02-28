using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerScript : MonoBehaviour {

    public float attackEachXFrames = 50;
    private List<Collider> listEnemyInRange;
    private Collider nearestEnemy;
    private float nearestEnemyDistance;
    float attackFrameCount;
    

	// Use this for initialization
	void Start () {
        listEnemyInRange = new List<Collider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (attackFrameCount == attackEachXFrames)
        {
            FindNearestEnemy();
            AttackNearestEnemy();
        }

        attackFrameCount++;

	}

    // Appeler lorsqu'un enemy rentre dans le radius de la tour
    void OnTriggerEnter(Collider otherCollider) {
		Debug.Log ("J'suis la");
		EnemyScript enemyScript = otherCollider.gameObject.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            listEnemyInRange.Add(otherCollider);
        }
    }
     // Appeler lorsqu'un enemy sort du radius de la tour
    void OnTriggerExit(Collider otherCollider) {
		Debug.Log ("J'suis pu la");
		EnemyScript enemyScript = otherCollider.gameObject.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            listEnemyInRange.Remove(otherCollider);
        }
    }

    // Appeler à chaque x frames, trouve l'ennemie le plus proche de la tour avant d'attaquer
    void FindNearestEnemy()
    {
        nearestEnemy = null;
        nearestEnemyDistance = 0;

        foreach (Collider c in listEnemyInRange)
        {
            float distance = Vector3.Distance(c.gameObject.transform.position, gameObject.transform.position);

            if (nearestEnemy == null)
            {
                nearestEnemy = c;
                nearestEnemyDistance = distance;
            }
            else if (distance < nearestEnemyDistance)
            {
                nearestEnemy = c;
                nearestEnemyDistance = distance;
            }
        }
    }
    
    // Appeler à chaque x frames, attaque l'ennemie le plus proche de la tour
    void AttackNearestEnemy()
    {
        // Add attack animation

        //nearestEnemy.gameObject.GetComponent<EnemyScript>().kill();

    }
}
