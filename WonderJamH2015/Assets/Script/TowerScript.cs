using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerScript : MonoBehaviour {

    public float attackEachXFrames = 300;
    public float projectileCooldown = 300;
    public Transform projectilePrefab;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    private List<Collider> listEnemyInRange;
    private Collider nearestEnemy;
    private float nearestEnemyDistance;
    private float attackFrameCount;
    private float currentProjectileCD;
    

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
            attackFrameCount = 0;
        }

        attackFrameCount++;
        currentProjectileCD++;

	}

    // Appeler lorsqu'un enemy rentre dans le radius de la tour
    void OnTriggerEnter(Collider otherCollider) {
		EnemyScript enemyScript = otherCollider.gameObject.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            listEnemyInRange.Add(otherCollider);
        }
    }
     // Appeler lorsqu'un enemy sort du radius de la tour
    void OnTriggerExit(Collider otherCollider) {
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
            //Debug.Log(distance);
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
        if (nearestEnemy != null)
        {
            if (currentProjectileCD >= projectileCooldown)
            {
                // Add attack animation
                Transform leProjectile;
                leProjectile = Instantiate(projectilePrefab, transform.position + new Vector3(0, 9f, 0), transform.rotation) as Transform;
                //leProjectile.GetComponent<TowerProjectile>().target = nearestEnemy.gameObject;

                // Move projectile to the position of throwing object + add some offset if needed.
                //leProjectile.position = transform.position + new Vector3(0, 9f, 0);
                
                // Calculate distance to target
                float target_Distance = Vector3.Distance(leProjectile.position, nearestEnemy.gameObject.transform.position);

                // Calculate the velocity needed to throw the object to the target at specified angle.
                float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
                
                // Extract the X  Y componenent of the velocity
                float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
                float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

                // Calculate flight time.
                float flightDuration = target_Distance / Vx;

                // Rotate projectile to face the target.
                leProjectile.rotation = Quaternion.LookRotation(nearestEnemy.gameObject.transform.position - leProjectile.position);

                float elapse_time = 0;
                Debug.Log(flightDuration);
                while (elapse_time < flightDuration)
                {
                    leProjectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

                    elapse_time += Time.deltaTime;
                }
                
                currentProjectileCD = 0;
            } 

        }
        
    }
}
