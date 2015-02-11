using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Npc))]
public class Seek : MonoBehaviour
{
    public Transform target;
    Npc npc;
    
    void Start ()
    {
        npc = GetComponent<Npc>();
    }
    
    void FixedUpdate ()
    {
        KinematicSeek();
    }

    void KinematicSeek()
    {
        Vector3 direction = target.position - transform.position;
        if(direction.magnitude > npc.ArriveRadius)
        {
            if(Vector3.Angle (transform.forward, direction) <= npc.ArcAngle)
            {
                // Translate while rotating (behavior B.i)
                transform.Translate (transform.forward * npc.SeekSpeed * Time.deltaTime, Space.World);
            }
            // Rotate towards target (behavior B.ii, if no translation occurs)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), npc.AngularSpeed * Time.deltaTime);
        }
    }
}
