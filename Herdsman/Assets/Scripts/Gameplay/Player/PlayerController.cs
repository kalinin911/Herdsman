using Gameplay.Movement;
using Input;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        private const float MOVE_SPEED = 5f;
        private const float MOVE_TRESHOLD = 0.1f;

        private Vector3 _targetPos;
        private bool _isMoving;
        private IMovementStrategy _movementStrategy;

        private void OnEnable()
        {
            InputHandler.OnMouseLeftClicked += HandleLeftMouseClick;
        }

        private void OnDisable()
        {
            InputHandler.OnMouseLeftClicked -= HandleLeftMouseClick;
        }

        private void Start()
        {
            _movementStrategy = new LinearMovementStrategy();
        }

        private void Update()
        {
            if (_isMoving)
            {
                MoveToTarget();
            }
        }

        private void HandleLeftMouseClick(Vector2 pos)
        {
            _targetPos = pos;
            _isMoving = true;
        }

        private void MoveToTarget()
        {
            _movementStrategy.Move(transform, _targetPos, MOVE_SPEED * Time.deltaTime);

            if (Vector3.Distance(transform.position, _targetPos) < MOVE_TRESHOLD)
            {
                _isMoving = false;
            }
        }
        
    }
}
