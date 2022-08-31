using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITargetable{}
public class Enemy : MonoBehaviour, ITargetable
{
    public int hp;
    public int moneyCarried;
    public UnityEngine.UI.Slider slider;
    public TMPro.TMP_Text textbox;

    private int maxHP;

    private void Start() 
    {
        maxHP = hp;
        updateSlider();
        textbox.text = moneyCarried.ToString();
    }

    private void updateSlider()
    {
        slider.value = (float)hp / maxHP;
    }

    private void checkDead()
    {
        if(hp <= 0)
        {
            GameManager.gameManager.GetMoney(moneyCarried);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        updateSlider();
        checkDead();
    }

    public void TakeContinuousDamage(int damage, int pulses, float timeInBetween)
    {
        StartCoroutine(continuousDamageTimer(damage, pulses, timeInBetween));
    }

    IEnumerator continuousDamageTimer(int damage, int pulses, float timeInBetween)
    {
        for(int i = 0; i < pulses; i++)
        {
            yield return new WaitForSeconds(timeInBetween);
            TakeDamage(damage);
        }
    }
}
