namespace _Scripts.Runtime.Enemy
{
    using System;
    using _Scripts.Runtime.Entities;
    using UnityEngine;

    public class EnemyBehavior : ElementBehavior
    {
        [SerializeField] private Transform target1, target2;
        [SerializeField] private Transform models;
        [SerializeField] private float     Speed;
        
        
        private Vector3 originalScale;
        private Transform currentTarget;

        private void Awake()
        {
            this.currentTarget = this.target1;
            this.originalScale = this.models.localScale;
        }

        public override void BehaviourExecute()
        {
            base.BehaviourExecute();
            //di chuyen
            this.models.position = Vector3.MoveTowards(this.models.position,
                this.currentTarget.position, Speed * Time.deltaTime);
        }

        protected override void Update()
        {
            base.Update();
            this.UpdateTarget();
            this.UpdateDirection();
        }

        private void UpdateTarget()
        {
            if (Vector2.Distance(this.models.position, this.target1.position) < .1f)
            {
                this.currentTarget = this.target2;
            }
            
            if(Vector2.Distance(this.models.position, this.target2.position) < .1f)
            {
                this.currentTarget = this.target1;
            }
        }

        private void UpdateDirection()
        {
            if(this.currentTarget == this.target1)
            {
                this.models.localScale = new Vector3(-this.originalScale.x, this.originalScale.y, this.originalScale.z);
            }
            else
            {
                this.models.localScale = new Vector3(this.originalScale.x, this.originalScale.y, this.originalScale.z);
            }
        }
    }
}