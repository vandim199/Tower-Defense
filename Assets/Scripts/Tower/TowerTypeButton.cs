using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerTypeButton : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField]
    private TMP_Text textbox;

    private void Start() 
    {
        textbox.text += " [" + prefab.GetComponent<Tower>().price + "]";
    }

    public void Place()
    {
        TowerPlacement.towerPlacement.SetBuildMode(prefab);
    }
}
