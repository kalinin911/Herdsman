using Gameplay.Animals.Sheep;

namespace Gameplay.Animals.States
{
    public class PatrollingState : IState
    {
        private readonly SheepBase _sheep;

        public PatrollingState(SheepBase sheep)
        {
            _sheep = sheep;
        }

        public void Enter()
        {;
            _sheep.SetNextWaypoint();
        }

        public void Execute()
        {
            if (_sheep.PlayerInRange() && _sheep.SheepManager.CanFollowPlayer())
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
        }
    }
}
