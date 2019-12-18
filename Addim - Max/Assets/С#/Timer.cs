using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timer;
    public GameObject timerView;

    // Update is called once per frame
    void Update()
    {
        TimerTimer();
        if (timer <=0)
        {
            //--TimerTimer();
            Debug.Log("Next Turn");
        }
    }

    public void TimerTimer()
    {
        timer -= Time.deltaTime;
        timerView.GetComponent<Text>().text = "" + timer;
    }
}
