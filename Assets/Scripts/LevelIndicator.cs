using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelIndicator : MonoBehaviour
{
    public TowerUpgrades.upgradeType upgradeType;

    public Image[] images;
    public int tier = 0;

    private Tower selectedTower;
    private Image buttonImage;

    // Start is called before the first frame update
    void Awake()
    {
        images[tier].color = Color.green;
        buttonImage = gameObject.GetComponent<Image>();
    }

    private void OnEnable() {
        SelectionState.onSelectionChanged += UpdateUI;
        SelectionState.onSelectionChanged += UpdateSelected;
        GameManager.onMoneyUpdated += CheckUpgradable;
    }

    private void UpdateSelected(Tower tower)
    {
        selectedTower = tower;
    }

    private void UpdateUI(Tower tower = null)
    {
        if(selectedTower != null)
        {
            tier = selectedTower.towerUpgrades.GetLevel(upgradeType);
            for (int i = 0; i < images.Length; i++)
            {
                if(tier >= i)
                    images[i].color = Color.green;
                else
                    images[i].color = Color.gray;
            }
        }
    }

    private void CheckUpgradable(int money)
    {
        if(money >= 50) buttonImage.color = Color.green;
        else buttonImage.color = Color.red;
    }

    public void UpgradeTier()
    {
        if(tier == images.Length) return;
        if(GameManager.gameManager.TryBuy(50))
        {
            selectedTower.towerUpgrades.Upgrade(upgradeType);
            tier = selectedTower.towerUpgrades.GetLevel(upgradeType);
            UpdateUI();
        }
    }
}
