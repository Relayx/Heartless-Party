using System;
using Code.Events;
using Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

public class Listener : MonoBehaviour
{
    // Fields --------------------------------------------
    private EventsService eventBus;   
    // ---------------------------------------------------



    // Properties ----------------------------------------
    
    // ---------------------------------------------------



    // Events --------------------------------------------
    
    // ---------------------------------------------------



    // Injection -----------------------------------------
    [Inject]
    private void Constructor(EventsService eventBus)
    {
        this.eventBus = eventBus;
    }
    // ---------------------------------------------------



    // Unity Methods -------------------------------------
    protected void Start()
    {
        eventBus.Subscribe<TestEvent>(eventData => {
            Debug.Log(eventData.Name);
        });
        
        eventBus.Subscribe<TestEvent>(eventData => {
            Debug.Log(eventData.Name + " Second!");
        });
    }
    
    protected void Update()
    {
        
    }
    // ---------------------------------------------------



    // Other Methods -------------------------------------
    
    // ---------------------------------------------------
}
