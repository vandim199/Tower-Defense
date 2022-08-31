using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;

    float timeLeft = 1;
    float maxTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            slider.value = timeLeft / maxTime;
        }
        else gameObject.SetActive(false);
    }

    public void ResetBar(float time)
    {
        maxTime = time;
        timeLeft = maxTime;
    }
}
