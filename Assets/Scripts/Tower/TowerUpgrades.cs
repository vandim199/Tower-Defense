using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrades : MonoBehaviour
{
    public delegate void OnUpgraded();
    public event OnUpgraded onUpgraded;

    [SerializeField]
    public enum upgradeType
    {
        speed,
        range,
        damage
    };
    public List<Upgrade> upgrades = new List<Upgrade>();
    Tower tower;

    void Start()
    {
        tower = gameObject.GetComponent<Tower>();

        foreach(Upgrade upgrade in upgrades)
        {
            upgrade.Start();
        }
    }

    public void Upgrade(upgradeType type)
    {
        foreach(Upgrade upgrade in upgrades)
        {
            if(upgrade.type == type)
            {
                upgrade.currentLevel++;
                upgrade.value = upgrade.levels[upgrade.currentLevel];
                onUpgraded();
            }
        }
    }

    public int GetLevel(upgradeType type)
    {
        int level = 0;

        foreach(Upgrade upgrade in upgrades)
        {
            if(upgrade.type == type)
            {
                level = upgrade.currentLevel;
            }
        }
        return level;
    }

    public float GetValue(upgradeType type)
    {
        float value = 0;

        foreach(Upgrade upgrade in upgrades)
        {
            if(upgrade.type == type)
            {
                value = upgrade.value;
            }
        }
        return value;
    }
}

[System.Serializable]
public class Upgrade
{
    [HideInInspector]
    public string upgradeName;
    public TowerUpgrades.upgradeType type;
    public int currentLevel;
    public float[] levels;

    public float value;

    public void Start()
    {
        upgradeName = type.ToString();
        value = levels[currentLevel];
    }
}
