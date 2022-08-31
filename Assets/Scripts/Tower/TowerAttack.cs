using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerAttack : MonoBehaviour
{
    private Tower tower;

    public float attackDelay;
    public float damage;
    public GameObject projectile;

    public UnityEvent onAttack;


    void Start()
    {
        tower = GetComponent<Tower>();

        tower.towerUpgrades.onUpgraded += UpdateValues;
        
        UpdateValues();
    }

    public void UpdateValues()
    {
        damage = tower.towerUpgrades.GetValue(TowerUpgrades.upgradeType.damage);
        attackDelay = tower.towerUpgrades.GetValue(TowerUpgrades.upgradeType.speed);
    }

    IEnumerator attackTimer()
    {
        yield return new WaitForSeconds(attackDelay);
        Attack();
    }

    public void Attack()
    {
        if(!tower.targets[0]) tower.targets.RemoveAt(0);

        if(tower.targets.Count > 0)
        {
            GameObject newProjectile = Instantiate(projectile);
            newProjectile.GetComponent<Projectile>().SetParameters(gameObject.transform, tower.targets, 0.1f, damage);
            onAttack.Invoke();
            StartCoroutine(attackTimer());
        }
    }
}
