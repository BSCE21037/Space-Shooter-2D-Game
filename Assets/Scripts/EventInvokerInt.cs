using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// script for invoking events with int parameter
/// </summary>
public class EventInvokerInt : MonoBehaviour
{
    protected Dictionary<EventName, UnityEvent<int>> Event = new Dictionary<EventName, UnityEvent<int>>();
    // Start is called before the first frame update
    /// <summary>
    /// Event invoker for int parameter function
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="listener"></param>
    public void AddListener(EventName eventName, UnityAction<int> listener)
    {
        if (Event.ContainsKey(eventName))//checking if eventName is already in the dictionary(key)
        {
            Event[eventName].AddListener(listener); //adding listener to the event
        }
        else
        {
            //otherwise we have a new event
            UnityEvent<int> newEvent = new UnityEvent<int>();
            newEvent.AddListener(listener);
            Event.Add(eventName, newEvent);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
