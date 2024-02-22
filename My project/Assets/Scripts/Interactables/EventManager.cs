using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public static event UnityAction TimerBegin;
    public static event UnityAction TimerEnd;

    public static event UnityAction<float> TimerUpdate;

    public static void OnTimerBegin() => TimerBegin?.Invoke();
    public static void OnTimerEnd() => TimerEnd?.Invoke();

    public static void OnTimerUpdate(float value) => TimerUpdate?.Invoke(value);
}
