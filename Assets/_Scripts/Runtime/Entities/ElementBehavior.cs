namespace _Scripts.Runtime.Entities
{
    using System;
    using UnityEngine;

    public abstract class ElementBehavior : MonoBehaviour
    {
        public bool IsEnabled { get; private set; }

        protected virtual void Awake()
        {
            this.IsEnabled = true;
        }

        protected virtual void Update()
        {
            if(!this.IsEnabled) return;
            this.BehaviourExecute();
        }
        
        public virtual void BehaviourExecute()
        {
            
        }
    }
}