using Gameplay.Animals.States;
using Gameplay.Movement;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    internal class WhiteSheep : SheepBase
    {
        private const float MOVE_SPEED = 1.5f;
        private const float FOLLOW_THRESHOLD = 2.5f;
        private const float WANDER_RADIUS = 1f;
        private const int PATROL_POINTS_MAX_AMOUNT = 10;

        private GameObject _player;
        private bool _isFollowing;

        public List<Vector3> _patrolPoints = new List<Vector3>();
        private int _currentPatrolPointIndex = 0;
        private IMovementStrategy _movementStrategy;


        private void Start()
        {
            SetPatrolPoints();
            _movementStrategy = new LinearMovementStrategy();
        }

        private void Update()
        {
            if (_isFollowing)
            {
                FollowTarget(_player);
            }

            else
            {
                PatrolBehaviour();
            }
        }

        public override void FollowTarget(GameObject target)
        {
            var distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance < FOLLOW_THRESHOLD)
            {
                return;
            }

            _movementStrategy.Move(transform, target.gameObject.transform.position, MOVE_SPEED * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isFollowing)
            {
                return;
            }

            if (collision.CompareTag("Player"))
            {
                _player = collision.gameObject;
                _isFollowing = true;
            }
        }

        private Vector3 GenerateNewPatrolPoint()
        {
            Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized;
            Vector3 randomPoint = transform.position + new Vector3(randomDirection.x, randomDirection.y, 0) * WANDER_RADIUS;

            return randomPoint;
        }

        private void SetPatrolPoints()
        {
            for (int i = 0; i < PATROL_POINTS_MAX_AMOUNT; i++)
            {
                _patrolPoints.Add(GenerateNewPatrolPoint());
            }
        }

        private void PatrolBehaviour()
        {
            _movementStrategy.Move(transform, _patrolPoints[_currentPatrolPointIndex], MOVE_SPEED * Time.deltaTime);

            if (Vector3.Distance(transform.position, _patrolPoints[_currentPatrolPointIndex]) <= 0)
            {
                _currentPatrolPointIndex++;
            }

            if (_currentPatrolPointIndex == PATROL_POINTS_MAX_AMOUNT)
            {
                _currentPatrolPointIndex = 0;
            }
        }
    }
}
