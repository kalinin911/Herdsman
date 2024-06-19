using Gameplay.Animals.States;
using Gameplay.Movement;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    public abstract class SheepBase : MonoBehaviour
    {
        protected float speed = 1.5f;
        protected float followRange = 5f;
        protected float patrolRadius = 2f;
        protected float followTreshold = 2.5f;
        protected int patrolPointsMaxAmount = 10;
        protected int currentWaypointIndex;
        protected Transform playerTransform;
        protected List<Vector3> patrolPoints = new List<Vector3>();
        protected IMovementStrategy movementStrategy;
        protected INPCState currentState;

        protected virtual void Start()
        {
            movementStrategy = new LinearMovementStrategy();
        }
        
        public virtual void Update()
        {
            currentState?.Execute();
        }

        public void ChangeState(INPCState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }

        public void SetNextWaypoint()
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % patrolPoints.Count;
        }

        public bool ReachedWaypoint()
        {
            return Vector2.Distance(transform.position, patrolPoints[currentWaypointIndex]) < 0.1f;
        }

        public bool ReachedPlayer()
        {
            return Vector2.Distance(transform.position, playerTransform.position) < followTreshold;
        }

        public void SetPlayerTransform(Transform playerTransform)
        {
            this.playerTransform = playerTransform;
        }

        public bool PlayerInRange()
        {
            if(playerTransform == null)
            {
                return false;
            }

            return Vector2.Distance(transform.position, playerTransform.position) < followRange;
        }

        public void MoveTowardsWaypoint()
        {
            movementStrategy.Move(transform, patrolPoints[currentWaypointIndex], speed * Time.deltaTime);
        }

        public void FollowPlayer()
        {
            movementStrategy.Move(transform, playerTransform.position, speed * Time.deltaTime);
        }

        public void SetMovementStrategy(IMovementStrategy strategy)
        {
            movementStrategy = strategy;
        }

        public Vector3 GenerateNewPatrolPoint()
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 randomPoint = transform.position + (Vector3)randomDirection * patrolRadius;

            return randomPoint;
        }

        public void SetPatrolPoints()
        {
            for (int i = 0; i < patrolPointsMaxAmount; i++)
            {
                patrolPoints.Add(GenerateNewPatrolPoint());
            }
        }
    }
}