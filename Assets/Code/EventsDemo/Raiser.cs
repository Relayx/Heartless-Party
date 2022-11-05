using Code.Events;
using Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

public class Raiser : MonoBehaviour
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
        Invoke("RaisingEvent", 2);
    }
    
    protected void Update()
    {
        
    }
    // ---------------------------------------------------



    // Other Methods -------------------------------------
    private void RaisingEvent()
    {
        eventBus.RaiseEvent<TestEvent>(new TestEvent()
        {
            Name = "Hello World"
        });
    }
    // ---------------------------------------------------
}
