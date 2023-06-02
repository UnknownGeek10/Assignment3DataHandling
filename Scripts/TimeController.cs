using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    public TextMeshProUGUI TimeText;

    private void OnEnable()
    {
        TimeManager.OnMinuteChange += UpdateTime;
        TimeManager.OnHourChange -= UpdateTime;
    }

    private void OnDisable()
    {
        
    }

   private void UpdateTime()
    {
        TimeText.text = $"{TimeManager.Hour:00}:{TimeManager.Minute:00}";
    }
}
