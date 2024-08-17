namespace _Scripts.Runtime.Manager
{
    using System;
    using UnityEngine;

    public class InputManager : MonoBehaviour
    {
        private       InputManager instance;
        public static InputManager Instance { get; private set; }
        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        private float valHori;
        private float valVert;
        private bool  isJumping;
        
        public float Horizontal => this.valHori;
        public float Vertical   => this.valVert;
        public bool  IsJumping  => this.isJumping;
        private void Update()
        {
            this.valHori = Input.GetAxis("Horizontal");
            this.valVert = Input.GetAxis("Vertical");
            
            this.isJumping = Input.GetButtonDown("Jump");
        }
    }
}