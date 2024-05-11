using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brains : MonoBehaviour
{
    Vehicle vehicle;
    public Transform target;
    Path path;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
        path = FindObjectOfType<Path>();
        target = path.GetClosestPoint(transform.position);
    }
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < 3)
        {
            target = path.GetNextPoint(transform.position);
        }
        Debug.DrawLine(transform.position, target.position, Color.red);
        Vector3 targetDir = target.position - transform.position;
        targetDir.Normalize();
        float angle = Vector3.SignedAngle(transform.forward, targetDir, Vector3.up);
        vehicle.Gas();
        if(angle > 3 || angle < -3)
        {
            vehicle.Turn(angle);
        }
        
    }
}
