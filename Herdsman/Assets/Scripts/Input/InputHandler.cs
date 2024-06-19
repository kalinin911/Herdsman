using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputHandler : MonoBehaviour
    {
        public static event Action<Vector2> OnMouseLeftClicked;

        private PlayerInputActions _inputActions;

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _inputActions.Player.Enable();
            _inputActions.Player.Click.performed += OnLeftClickPerformed;
        }

        private void OnDisable()
        {
            _inputActions.Player.Click.performed -= OnLeftClickPerformed;
            _inputActions.Player.Disable();
        }

        private void OnLeftClickPerformed(InputAction.CallbackContext context)
        {
            var mousePos = Mouse.current.position.ReadValue();
            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            OnMouseLeftClicked?.Invoke(worldPos);
        }
    }
}

