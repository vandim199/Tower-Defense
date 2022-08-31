using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public static TowerPlacement towerPlacement{get;set;}

    // Start is called before the first frame update
    void Awake()
    {
        if(towerPlacement == null) towerPlacement = this;
        else Destroy(this);
    }
    
    public void SetBuildMode(GameObject newTowerPrefab)
    {
        FSM.fsm.ChangeState<BuildState>();
        (FSM.fsm.GetState<BuildState>() as BuildState).towerPrefab = newTowerPrefab;
    }

    public void SetSelectionMode()
    {
        FSM.fsm.ChangeState<SelectionState>();
    }

    public void DestroyTower()
    {
        (FSM.fsm.GetState<SelectionState>() as SelectionState).DestroyTower();
    }
}
