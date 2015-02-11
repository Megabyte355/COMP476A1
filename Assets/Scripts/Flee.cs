using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Npc))]
public class Flee : MonoBehaviour
{
    public Transform target;
    Npc npc;
    
    void Start ()
    {
        npc = GetComponent<Npc>();
    }
    
    void FixedUpdate ()
    {
        KinematicFlee();
    }
    
    void KinematicFlee()
    {
        Vector3 fleeDirection = transform.position - target.position;
        if(fleeDirection.magnitude < npc.FleeDistanceThreshold)
        {
            // Step away directly while ignoring orientation (behavior C.i)
            transform.Translate (fleeDirection.normalized * npc.FleeSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            // Stops, rotate, then continue moving away (behavior C.ii)
            if(Vector3.Angle (transform.forward, fleeDirection) <= npc.AngleThreshold)
            {
                transform.Translate (transform.forward * npc.SeekSpeed * Time.deltaTime, Space.World);
            }
        }
        // Rotation for both behaviors
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(fleeDirection), npc.AngularSpeed * Time.deltaTime);
    }
}
