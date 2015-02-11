using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Npc))]
public class Arrive : MonoBehaviour
{
    public Transform target;
    Npc npc;

    void Start ()
    {
        npc = GetComponent<Npc>();
    }

    void FixedUpdate ()
    {
        KinematicArrive();
    }

    void KinematicArrive()
    {
        Vector3 direction = (target.position - transform.position);
        if(direction.magnitude <= npc.DistanceThreshold)
        {
            // Step directly to target (behavior A.i)
            transform.position = target.position;
        }
        else if(direction.magnitude <= npc.ArriveRadius)
        {
            if(Vector3.Angle (transform.forward, direction) <= npc.AngleThreshold)
            {
                transform.Translate (direction.normalized * npc.ArriveSpeed * Time.deltaTime);
            }
            else
            {
                // Rotate towards target on the spot before moving (behavior A.ii)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), npc.AngularSpeed * Time.deltaTime);
            }
        }
    }
}
