using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    TMPro.TMP_Text textBox;
    
    private void Awake()
    {
        textBox = gameObject.GetComponent<TMPro.TMP_Text>();
        GameManager.onMoneyUpdated += UpdateText;
    }

    private void UpdateText(int value)
    {
        textBox.text = "Money: " + value;
    }
}
