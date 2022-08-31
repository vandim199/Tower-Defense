using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public delegate void OnMoneyUpdated(int value);
    public static event OnMoneyUpdated onMoneyUpdated;

    public int money = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if(gameManager == null) gameManager = this;
        else Destroy(this);

        SelectionState.onSelectionChanged += updateMoney;
    }

    void Start()
    {
        updateMoney();
    }

    private void updateMoney(Tower tower = null)
    {
        onMoneyUpdated(this.money);
    }

    public void GetMoney(int amount)
    {
        money += amount;
        onMoneyUpdated(this.money);
    }

    public bool CanBuy(int price)
    {
        return (money >= price);
    }

    public bool TryBuy(int price)
    {
        if(money >= price)
        {
            money -= price;
            onMoneyUpdated(this.money);
            return true;
        }
        else return false;
    }
}
