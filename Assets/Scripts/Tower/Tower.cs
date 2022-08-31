using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [HideInInspector]
    public TowerUpgrades towerUpgrades;
    public float range = 1;
    public GameObject occupiedTile;
    public int price;

    public List<Enemy> targets;

    public UnityEvent OnTargetFound;
    
    void Awake()
    {
        towerUpgrades = gameObject.GetComponent<TowerUpgrades>();
        
        towerUpgrades.onUpgraded += UpdateValues;
        
        UpdateValues();
    }

    void UpdateValues()
    {
        range = towerUpgrades.GetValue(TowerUpgrades.upgradeType.range);
        GetComponent<SphereCollider>().radius = range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ITargetable>() != null)
        {
            targets.Add(other.gameObject.GetComponent<Enemy>());

            if(targets.Count == 1)
            {
                OnTargetFound.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.GetComponent<ITargetable>() != null)
        {
            targets.Remove(other.gameObject.GetComponent<Enemy>());
        }
    }
}
