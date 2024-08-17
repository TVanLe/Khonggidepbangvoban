namespace _Scripts.Runtime.Enemy
{
    using System;
    using UnityEngine;

    public class EnemyController : MonoBehaviour
    {
        public EnemyAttack   EnemyAttack;
        public EnemyHealth   EnemyHealth;
        public EnemyBehavior EnemyBehavior;

        private void Awake() { }

        private void Update()
        {
            
        }
    }
}