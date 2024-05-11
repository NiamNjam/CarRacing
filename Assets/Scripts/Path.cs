using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private Transform[] points;

    public Transform GetNextPoint(Vector3 position)
    {
        int index = GetClosestPointIndex(position);
        index++;
        if (index >= points.Length) index = 0;
        return points[index];
    }

    public int GetClosestPointIndex(Vector3 position)
    {
        float minDistance = float.MaxValue;
        int index = 0;

        for (int i = 0; i < points.Length; i++)
        {
            float distance = Vector3.Distance(position, points[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                index = i;
            }
        }

        return index;
    }

    public Transform GetClosestPoint(Vector3 point)
    {
        float minDistance = float.MaxValue;
        Transform closestPoint = null;

        for (int i = 0; i < points.Length; i++)
        {
            var distance = Vector3.Distance(point, points[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPoint = points[i];
            }
        }

        return closestPoint;
    }

    void Start()
    {
        points = GetComponentsInChildren<Transform>()[1..];
    }
}