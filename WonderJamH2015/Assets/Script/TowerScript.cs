using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerScript : MonoBehaviour {

    public float attackEachXFrames = 300;
    public float projectileCooldown = 300;
    public Transform projectilePrefab;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    public bool AttackMode = true; // true = nearest, false = most far
    private List<Collider> listEnemyInRange;
    private Collider targetEnemy;
    private float targetEnemyDistance;
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
            if (AttackMode){ FindNearestEnemy(); }
            else { FindMostFarEnemy(); }
            AttackTargetEnemy();
            attackFrameCount = 0;
        }

        attackFrameCount++;
        currentProjectileCD++;

	}

    // Appeler lorsqu'un enemy rentre dans le radius de la tour
    void OnTriggerEnter(Collider otherCollider) {
        if (otherCollider.tag == "Enemy")
        {
            listEnemyInRange.Add(otherCollider);
        }
    }
     // Appeler lorsqu'un enemy sort du radius de la tour
    void OnTriggerExit(Collider otherCollider) {
        if (otherCollider.tag == "Enemy")
        {
            listEnemyInRange.Remove(otherCollider);
        }
    }

    void OnMouseDown() {
        if (AttackMode) { AttackMode = false; }
        else { AttackMode = true; }
        Debug.Log("AttackMode Changed =D");
    }

    // Appeler à chaque x frames, trouve l'ennemie le plus proche de la tour avant d'attaquer
    void FindNearestEnemy()
    {
        targetEnemy = null;
        targetEnemyDistance = 0;

        foreach (Collider c in listEnemyInRange)
        {
            if (c != null)
            {
                float distance = Vector3.Distance(c.gameObject.transform.position, gameObject.transform.position);
                if (targetEnemy == null)
                {
                    targetEnemy = c;
                    targetEnemyDistance = distance;
                }
                else if (distance < targetEnemyDistance)
                {
                    targetEnemy = c;
                    targetEnemyDistance = distance;
                }
            }
        }
    }

    // Trouve l'enemie le plus loin dans le range de la tour avant d'attaquer
    void FindMostFarEnemy()
    {
        targetEnemy = null;
        targetEnemyDistance = 0;

        foreach (Collider c in listEnemyInRange)
        {
            if (c != null)
            {
                float distance = Vector3.Distance(c.gameObject.transform.position, gameObject.transform.position);
                if (targetEnemy == null)
                {
                    targetEnemy = c;
                    targetEnemyDistance = distance;
                }
                else if (distance > targetEnemyDistance)
                {
                    targetEnemy = c;
                    targetEnemyDistance = distance;
                }
            }
        }
    }
    
    // Appeler à chaque x frames, attaque l'ennemie le plus proche de la tour
    void AttackTargetEnemy()
    {
        if (targetEnemy != null)
        {
            if (currentProjectileCD >= projectileCooldown)
            {
                // Add attack animation
                Transform leProjectile;
                leProjectile = Instantiate(projectilePrefab, transform.GetChild(2).position + new Vector3(0, 1.6f, 0.0f), transform.rotation) as Transform;
                //leProjectile.GetComponent<TowerProjectile>().target = nearestEnemy.gameObject;
                StartCoroutine(ThrowProjectile(targetEnemy.gameObject.transform, leProjectile, transform));
                
                currentProjectileCD = 0;
            } 
        }
    }

    // Fonction qui lance le projectile jusqu'au target
    IEnumerator ThrowProjectile(Transform target, Transform projectile, Transform tower)
    {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(0.0f);
        
        // Move projectile to the position of throwing object + add some offset if needed.
        //projectile.position = tower.GetChild(0).position + new Vector3(0, 7f, 0.0f);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(projectile.position, target.position + (target.forward * 2.5f));

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        projectile.rotation = Quaternion.LookRotation(target.position - projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }

        projectile.gameObject.rigidbody.useGravity = true;
    }
}
