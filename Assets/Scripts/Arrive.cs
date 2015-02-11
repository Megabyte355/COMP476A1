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
        Vector3 direction = (target.position - transform.position);
        if(direction.magnitude <= npc.DistanceThreshold)
        {
            transform.position = target.position;
        }
        else if(direction.magnitude <= npc.ArriveRadius)
        {
            transform.Translate (direction.normalized * npc.ArriveSpeed * Time.deltaTime);
        }
    }
}
