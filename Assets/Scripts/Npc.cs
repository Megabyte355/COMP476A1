using UnityEngine;
using System.Collections;

public class Npc : MonoBehaviour
{
    Mode implementationMode;
    enum NpcState { Idle, Arrive, Wander, Flee, Tagged };
    [SerializeField]
    NpcState currentState = NpcState.Idle;

    // Kinematic seek and arrive
    public float SeekSpeed;
    public float ArriveSpeed;
    public float ArriveRadius;
    public float TimeToTarget;
    public float DistanceThreshold;

    // Kinematic flee
    public float FleeSpeed;
    public float FleeDistanceThreshold;



    // Steering seek and arrive
    public float MaxAcceleration;
    public float MaxVelocity;
    public Vector3 Velocity;    // TODO: remove
    public float VelocityThreshold;
    public float SlowDownRadius;

    // Align
    public float MaxAngularAcceleration;
    public float MaxAngularVelocity;
    public float AngularVelocity;   // TODO : remove
    public float AngularTimeToTarget;
    public float SlowDownOrientation;

    // Turning
    public float ArcAngle;
    public float ArcDistance;
    public float AngularSpeed;
    public float AngleThreshold;


    // TODO : maybe we should remove this
    public Transform RotationTarget;


    void Start()
    {
        implementationMode = GameObject.FindGameObjectWithTag("Settings").GetComponent<Mode>();
    }

    public bool IsKinematicMode()
    {
        return implementationMode.IsKinematic();
    }

    public bool IsSteeringMode()
    {
        return implementationMode.IsSteering();
    }

//    void FixedUpdate()
//    {
//
//        if(IsSteeringMode())
//        {
//            // Translate
//            if(Velocity.magnitude > MaxVelocity)
//            {
//                Velocity = Velocity.normalized * MaxVelocity;
//            }
//            transform.position += Velocity * Time.deltaTime;
//
//            // Rotate
//
//            if(RotationTarget != null)
//            {
//                if(AngularVelocity > MaxAngularVelocity)
//                {
//                    AngularVelocity = MaxAngularVelocity;
//                }
//                Vector3 toTarget = RotationTarget.position - transform.position;
//                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toTarget), AngularVelocity * Time.deltaTime);
//            }
//
//
//        }
//    }
}
