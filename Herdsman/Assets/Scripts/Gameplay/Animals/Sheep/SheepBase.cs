using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    public abstract class SheepBase : MonoBehaviour
    {
        public abstract void FollowTarget(GameObject target);
    }
}
