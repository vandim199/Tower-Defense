using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool occupied = false;
    public GameObject tower;

    public Material outline;
    public Material transparent;

    private Renderer rend;

    void Start() 
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        Material[] matArray = rend.materials;
        
        if(FSM.fsm.CheckState<BuildState>() && !occupied)
        {
           matArray[2] = outline;
        }
        else matArray[2] = transparent;

        rend.materials = matArray;
    }
}
