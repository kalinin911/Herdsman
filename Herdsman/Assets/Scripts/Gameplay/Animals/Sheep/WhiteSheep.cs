using Gameplay.Animals.States;
using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    internal class WhiteSheep : SheepBase
    {
        protected override void Start()
        {
            base.Start();
            SetPatrolPoints();
            ChangeState(new PatrollingState(this));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                SetPlayerTransform(collision.transform);
                ChangeState(new FollowingState(this));
            }
        }

    }
}
