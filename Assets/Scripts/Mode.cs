using UnityEngine;
using System.Collections;

public class Mode : MonoBehaviour
{
    enum MovementMode { Kinematic, Steering };
    [SerializeField]
    MovementMode mode;

    void Start ()
    {
        mode = MovementMode.Kinematic;
    }

    void Update ()
    {
        // "Jump" is mapped to spacebar key
        if (Input.GetButtonDown ("Jump")) {
            // Change mode
            mode = (mode == MovementMode.Kinematic) ? MovementMode.Steering : MovementMode.Kinematic;
        }
    }

    bool IsKinematic ()
    {
        return mode == MovementMode.Kinematic;
    }

    bool IsSteering ()
    {
        return mode == MovementMode.Steering;
    }
}
