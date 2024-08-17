namespace _Scripts.Runtime.Entities
{
    using System;
    using UnityEngine;

    public abstract class ElementHealth : MonoBehaviour, ITakeDamage
    {
        private int maxHp;
        public int MaxHp
        {
            get => this.maxHp;
            set => this.maxHp = value;
        }
        
        private int currentHp;
        public int CurrentHp
        {
            get => this.currentHp;
            set => this.currentHp = value;
        }

        protected virtual void Awake()
        {
            this.currentHp = this.maxHp;
        }

        public virtual void TakeDamage(int damage)
        {
            this.currentHp -= damage;
            if (this.currentHp <= 0)
            {
                //die 
                this.OnDie();
            }
        }
        
        public virtual void Heal(int heal)
        {
            this.currentHp += heal;
            if (this.currentHp > this.maxHp)
            {
                this.currentHp = this.maxHp;
            }
            else
            {
                this.OnHeal();
            }
        }

        protected virtual void OnHeal()
        {
            //todo logic in hear
        }
        protected virtual void OnDie()
        {
            //todo logic in hear
        }
    }
}