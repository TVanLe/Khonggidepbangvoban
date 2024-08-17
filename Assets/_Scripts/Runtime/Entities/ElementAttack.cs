namespace _Scripts.Runtime.Entities
{
    using System;
    using UnityEngine;
    using UnityEngine.Serialization;

    public abstract class ElementAttack : MonoBehaviour
    {
        public bool IsEnable { get; private set; }
        public bool isAttack = false;

        protected virtual void Awake()
        {
            this.IsEnable = true;
        }

        protected virtual void Update()
        {
            if(!this.IsEnable) return;
            if (this.CanAttack())
            {
                this.Attack();
            }
        }
        
        public abstract bool CanAttack();
        public abstract void Attack();
    }
}