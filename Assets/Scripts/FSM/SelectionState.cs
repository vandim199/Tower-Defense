using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionState : State
{
    public LayerMask layers;
    public delegate void OnSelectionChanged(Tower selected);
    public static event OnSelectionChanged onSelectionChanged;

    public Tower selected;
    private Tower lastSelected;
    private bool canSelect;
    private bool isOverUI;
    public GameObject menu;

    RaycastHit hit;

    private void Start() {
        FSM.fsm.states.Add(this.GetType(), base.GetState());
    }

    public override void Mouse()
    {
        if(lastSelected != selected) onSelectionChanged(selected);
        lastSelected = selected;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layers))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.white);
            canSelect = hit.collider.gameObject.GetComponent<Tile>().occupied;
        }

        isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

        if(Input.GetMouseButtonDown(0))
        {
            if(canSelect)
                selected = hit.collider.gameObject.GetComponent<Tile>().tower.GetComponent<Tower>();
            else if(!isOverUI) selected = null;
        }
    }

    public override void OnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(canSelect)
                selected = hit.collider.gameObject.GetComponent<Tile>().tower.GetComponent<Tower>();
            else if(!isOverUI) selected = null;
        }

        menu.SetActive(selected != null);
    }

    public void DestroyTower()
    {
        selected.occupiedTile.GetComponent<Tile>().occupied = false;
        GameManager.gameManager.GetMoney(selected.price);
        Destroy(selected.gameObject);
    }
}

