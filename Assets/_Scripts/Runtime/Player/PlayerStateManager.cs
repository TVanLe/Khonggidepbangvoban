namespace _Scripts.Runtime.Player
{
    using System;
    using _Scripts.Runtime.Manager;
    using Unity.VisualScripting;
    using UnityEngine;

    public class PlayerStateManager : MonoBehaviour
    {
        public bool IsMoving  => InputManager.Instance.Horizontal != 0;
        public bool IsJumping => InputManager.Instance.IsJumping;

        
        public static PlayerStateManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}