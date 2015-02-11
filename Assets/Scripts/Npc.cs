using UnityEngine;
using System.Collections;

public class Npc : MonoBehaviour
{
    enum NpcState { Idle, Arrive, Wander, Flee };
    [SerializeField]
    NpcState currentState = NpcState.Idle;

    // Kinematic seek and arrive
    public float SeekSpeed;
    public float ArriveSpeed;
    public float ArriveRadius;
    public float DistanceThreshold;

    // Turning
    public float ArcAngle;
    public float ArcDistance;
    public float AngularSpeed;
    public float AngleThreshold;

    // Kinematic flee
    public float FleeSpeed;
    public float FleeDistanceThreshold;
}
