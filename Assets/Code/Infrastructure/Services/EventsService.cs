using System;
using System.Collections.Generic;
using Code.Events;

namespace Code.Infrastructure.Services
{
    public class EventsService
    {
        private readonly Dictionary<Type, IDelegateWrapper> subscribers = new();

        public void Subscribe<TEvent>(Action<TEvent> callback) where TEvent : struct, IEvent
        {
            if (!subscribers.ContainsKey(typeof(TEvent)))
            {
                subscribers.Add(typeof(TEvent), new DelegateWrapper<TEvent>());
            }

            if (subscribers[typeof(TEvent)] is DelegateWrapper<TEvent> act) act.Action += callback;
        }
        
        public void Unsubscribe<TEvent>(Action<TEvent> callback) where TEvent : struct, IEvent
        {
            if (!subscribers.ContainsKey(typeof(TEvent)))
                return;
            
            if (subscribers[typeof(TEvent)] is DelegateWrapper<TEvent> act) act.Action -= callback;

            if (subscribers[typeof(TEvent)] == null)
            {
                subscribers.Remove(typeof(TEvent));
            }
        }
        
        public void RaiseEvent<TEvent>(TEvent eventPayload) where TEvent : struct, IEvent
        {
            if (!subscribers.ContainsKey(typeof(TEvent)))
                return;
            
            (subscribers[typeof(TEvent)] as DelegateWrapper<TEvent>)?.Action?.Invoke(eventPayload);
        }
    }
}

internal interface IDelegateWrapper
{
    
}

internal class DelegateWrapper<T> : IDelegateWrapper
{
    public Action<T> Action;
}