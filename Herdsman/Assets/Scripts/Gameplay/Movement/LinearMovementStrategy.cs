using UnityEngine;

namespace Gameplay.Movement
{
    public class LinearMovementStrategy : IMovementStrategy
    {
        public void Move(Transform npcTransform, Vector3 targetPosition, float speed)
        {
            npcTransform.position = Vector2.MoveTowards(npcTransform.position, targetPosition, speed);
        }
    }
}
