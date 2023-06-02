using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChange;
    public static Action OnHourChange;
    public static int Minute { get; private set; }
    public static int Hour { get; private set; }


    private float MinuteToRealTime = 0.15f;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Hour = 8;
        Timer = MinuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Minute++;
            OnMinuteChange?.Invoke();
            if (Minute >= 60) {

                Hour++;
                Minute = 0;
                OnHourChange?.Invoke();
            }
            Timer = MinuteToRealTime;
        }

        if (Hour > 23)
        {
            Hour = 00;
        }
    }
}
