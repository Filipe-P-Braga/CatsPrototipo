using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Subject", menuName = "Event Channels/Subject")]
public class Subject : ScriptableObject
{
    public event Action<bool> OnPettingEventRaised;
    public event Action<bool> OnFullBarEventRaised;

    public void RaisePettingEvent(bool petting)
    {
        OnPettingEventRaised?.Invoke(petting);
    }


    public void RaiseFullBarEvent(bool paused)
    {
        OnFullBarEventRaised?.Invoke(paused);
    }
}
