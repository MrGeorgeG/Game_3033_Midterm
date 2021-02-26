using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float walkSpeed;
        [SerializeField] private float RunSpeed;
        [SerializeField] private float JumpForce;

        private PlayerController PlayerController;

        private Transform PlayerTransform;

        private Vector2 InputVector = Vector2.zero;
        private Vector3 MoveDirection = Vector3.zero;


        private void Awake()
        {
            PlayerTransform = transform;
            PlayerController = GetComponent<PlayerController>();
        }

        public void OnMovement(InputValue value)
        {
            InputVector = value.Get<Vector2>();
        }

        private void Update()
        {
            if (PlayerController.IsJumping) return;

            if (!(InputVector.magnitude > 0)) return;

            MoveDirection = PlayerTransform.forward * InputVector.y + PlayerTransform .right * InputVector.x;

            float currentSpeed = PlayerController.isRunning ? RunSpeed : walkSpeed;

            Vector3 movementDirection = MoveDirection * (currentSpeed * Time.deltaTime);

            PlayerTransform.position += movementDirection;
        }

    }

}
