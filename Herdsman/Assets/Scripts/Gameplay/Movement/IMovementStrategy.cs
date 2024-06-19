using UnityEngine;

namespace Gameplay.Movement
{
    public interface IMovementStrategy
    {
        void Move(Transform npcPosition, Vector3 targetPosition, float speed);
    }
}
