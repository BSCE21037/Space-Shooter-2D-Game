using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static EventName;
// using static;

/// <summary>
/// script to manage all events
/// </summary>
public static class EventManager
{

    #region Fields

    //dictionary to store all invokers
    static Dictionary<EventName, List<EventInvokerInt>> invokers = new Dictionary<EventName, List<EventInvokerInt>>();
    //dictionary to store all listeners
    static Dictionary<EventName, List<UnityAction<int>>> listeners = new Dictionary<EventName, List<UnityAction<int>>>();

    #endregion 


    // Start is called before the first frame update
    /// <summary>
    /// initialize all dictionaries
    /// </summary>
    public static void Initialize()
    {
        //initialize all dictionaries
        foreach (EventName name in EventName.GetValues(typeof(EventName)))
        {
            if (!invokers.ContainsKey(name))//checking if the dictionary already contains the key
            {
                //if not, add the key and value
                invokers.Add(name, new List<EventInvokerInt>());
                listeners.Add(name, new List<UnityAction<int>>());
            }
            else
            {
                //if yes, clear the list
                invokers[name].Clear();
                listeners[name].Clear();
            }
        }
    }

    public static void AddInvoker(EventName eventName, EventInvokerInt invoker)
    {
        //add invoker to the dictionary
        foreach (UnityAction<int> listener in listeners[eventName])
        {
            //add listener to the invoker
            invoker.AddListener(eventName, listener);
        }
        //add invoker to the dictionary
        invokers[eventName].Add(invoker); 
    }

    public static void AddListener(EventName eventName, UnityAction<int> listener)
    {
        //add listener to the dictionary
        foreach (EventInvokerInt invoker in invokers[eventName])
        {
            //add listener to the invoker
            invoker.AddListener(eventName, listener);
        }
        //add listener to the dictionary
        listeners[eventName].Add(listener);
    }

    public static void RemoveInvoker(EventName eventName, EventInvokerInt invoker)
    {
        //remove invoker from the dictionary
        invokers[eventName].Remove(invoker);
    }

}
