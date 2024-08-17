namespace _Scripts.Runtime.Player
{
    using System;
    using _Scripts.Runtime.Manager;
    using UnityEngine;
    
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Player Movement")] 
        [SerializeField] private float speed = 5f;
        [SerializeField] private float       jumpForce = 5f;


        [Header("Components")] 
        [SerializeField] private Transform models;
        [SerializeField] private Rigidbody2D rigidbody2D;

        [Header("Check grounded")] 
        [SerializeField] private Transform pointToCheckGrounded;
        [SerializeField] private LayerMask layer;
        [SerializeField] private bool isGrounded;
        
        
        //private
        Vector3 originalScale;
        
        //Singletons
        InputManager inputManager => InputManager.Instance;
        PlayerStateManager playerStateManager => PlayerStateManager.Instance;

        private void Awake()
        {
            this.originalScale = this.models.localScale;
        }

        private void Update()
        {
            this.Move();
            this.Jump();
            this.CheckGround();
        }

        public void Move()
        {
            this.rigidbody2D.velocity = new Vector2(this.inputManager.Horizontal * this.speed,
                this.rigidbody2D.velocity.y);
            this.DirectionModels(this.inputManager.Horizontal);
        }

        public void Jump()
        {
            if (this.playerStateManager.IsJumping && this.isGrounded)
            {
                this.rigidbody2D.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
            }
        }

        private void CheckGround()
        {
            this.isGrounded = Physics2D.OverlapBox(this.pointToCheckGrounded.position,
                new Vector2(0.19f,0.04f), 0f,this.layer);
        }

        private void DirectionModels(float x)
        {
            var value = x >= 0 ? 1 : -1;
            this.models.localScale = new Vector3(this.originalScale.x * value, this.originalScale.y, this.originalScale.z);
        }
    }
}