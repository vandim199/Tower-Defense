using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Waypoints waypointsInstance {get; set;}

    public Transform[] points;

    // Start is called before the first frame update
    void Awake()
    {
        if(waypointsInstance == null) waypointsInstance = this;
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
