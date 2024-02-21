using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RunTimerScript : MonoBehaviour
{
    private TMP_Text timerText;
    enum TimerType {Countdown, Stopwatch}

    [SerializeField] private TimerType timerType;
    [SerializeField] private float timeToDisplay = 0f;

    private bool isCounting;
    // Start is called before the first frame update

    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        EventManager.TimerBegin += EventManagerOnTimerBegin;
        EventManager.TimerEnd += EventManagerOnTimerEnd;
        EventManager.TimerUpdate += EventManagerOnTimerUpdate;
    }
    private void OnDisable()
    {
        EventManager.TimerBegin -= EventManagerOnTimerBegin;
        EventManager.TimerEnd -= EventManagerOnTimerEnd;
        EventManager.TimerUpdate -= EventManagerOnTimerUpdate;
    }
  
    private void EventManagerOnTimerEnd() => isCounting = false;
    
       
    
    private void EventManagerOnTimerBegin() => isCounting = true;
    
    private void EventManagerOnTimerUpdate(float value) => timeToDisplay = value;
    
      

    // Update is called once per frame
    void Update()
    {
        if (!isCounting) return;
        

        if (timerType == TimerType.Countdown)
        { 
            timeToDisplay -= Time.deltaTime; 
        }
        else
        {
            (timeToDisplay)+= Time.deltaTime;
        }


        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay -60);
        timerText.text = timeSpan.ToString(@"mm\:ss\:ff");
    }
}
