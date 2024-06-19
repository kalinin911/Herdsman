using Gameplay.Animals.States;
using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    internal class WhiteSheep : SheepBase
    {
        //private const float MOVE_SPEED = 1.5f;
        //private const float FOLLOW_THRESHOLD = 2.5f;
        //private const float WANDER_RADIUS = 1f;
        //private const int PATROL_POINTS_MAX_AMOUNT = 10;

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
