using System;
using System.Collections;
using UnityEngine;

public class EventBroadcaster : MonoBehaviour
{
    public static EventBroadcaster instance;

    public static Action<IItemInterface> OnItemPickup;
    
    private void Awake()
    {
        if (instance != null &&  instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }        
    }
}
