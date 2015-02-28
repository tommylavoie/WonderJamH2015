using UnityEngine;
using System.Collections;
using System;

public class TowerProjectile : MonoBehaviour
{

    //public GameObject target;
    //public float speed = 25;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void ThrowProjectile()
    {
        // Short delay added before Projectile is thrown
        //yield return new WaitForSeconds(0.5f);

        // Move projectile to the position of throwing object + add some offset if needed.
        transform.position = target.transform.position + new Vector3(0, 0.0f, 0.8f);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(transform.position, target.transform.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            //yield return null;
        }
    }*/
}
