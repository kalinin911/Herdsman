using Gameplay.Animals.Sheep;
using System;
namespace Gameplay.Animals.States
{
    public class PatrollingState : INPCState
    {
        private readonly SheepBase _sheep;

        public PatrollingState(SheepBase sheep)
        {
            _sheep = sheep;
        }

        public void Enter()
        {
            Console.WriteLine("Entering patrolling state");
            _sheep.SetNextWaypoint();
        }

        public void Execute()
        {
            if (_sheep.PlayerInRange())
            {
                _sheep.ChangeState(new FollowingState(_sheep));
            }

            if(_sheep.ReachedWaypoint())
            {
                _sheep.SetNextWaypoint();
            }

            else
            {
                _sheep.MoveTowardsWaypoint();
            }

        }

        public void Exit()
        {
            Console.WriteLine("Exiting patrolling state");
        }
    }
}
