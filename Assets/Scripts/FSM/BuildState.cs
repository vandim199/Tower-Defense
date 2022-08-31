using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : State
{
    public LayerMask layers;
    public GameObject outline;
    private bool canPlace;
    public GameObject towerPrefab;

    RaycastHit hit;

    private void Start() {
        FSM.fsm.states.Add(this.GetType(), base.GetState());

        outline = Instantiate(outline);
        outline.SetActive(false);
    }

    public override void Mouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layers))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.white);
            outline.transform.position = hit.transform.position + Vector3.up * (hit.point.y + outline.transform.lossyScale.y);

            canPlace = !hit.collider.gameObject.GetComponent<Tile>().occupied;
        }
        else canPlace = false;
    }

    public override void OnClick()
    {
        if(Input.GetMouseButtonDown(0) && canPlace && 
        GameManager.gameManager.TryBuy(towerPrefab.GetComponent<Tower>().price))
        {
            hit.collider.gameObject.GetComponent<Tile>().tower = Instantiate(towerPrefab, hit.transform.position + Vector3.up * (hit.point.y), Quaternion.identity);
            hit.collider.gameObject.GetComponent<Tile>().occupied = true;
            hit.collider.gameObject.GetComponent<Tile>().tower.GetComponent<Tower>().occupiedTile = hit.collider.gameObject;
        }
        
        outline.SetActive(canPlace);
    }
}
