using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    [Header("Path")]
    public float progress = 0;

    private float threshold = 0.1f;
    private Transform target;
    private int waypointIndex = 0;
    private Vector3 direction = Vector3.zero;
    private bool endReached = false;

    void Start()
    {
        speed /= 100;
        target = Waypoints.waypointsInstance.points[0];
    }

    void FixedUpdate()
    {
        progress += speed;

        if(!endReached)
        {
            Move();
            WaypointManager();
        }
        else Destroy(gameObject);
    }

    private void Move()
    {
        direction = (target.position - gameObject.transform.position).normalized;
        transform.Translate(direction * speed);
    }

    private void WaypointManager()
    {
        if(Vector3.Distance(gameObject.transform.position, target.position) < threshold)
        {
            if(waypointIndex < Waypoints.waypointsInstance.points.Length - 1)
            {
                waypointIndex++;
                target = Waypoints.waypointsInstance.points[waypointIndex];
            }
            else endReached = true;
        }
    }
}
