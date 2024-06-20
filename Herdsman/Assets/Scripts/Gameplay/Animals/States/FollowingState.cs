using Gameplay.Animals.Sheep;

namespace Gameplay.Animals.States
{
    public class FollowingState : IState
    {
        private readonly SheepBase _sheep;
        
        public FollowingState(SheepBase sheep)
        {
            _sheep = sheep;
            _sheep.SheepManager.IncrementFollowingCount();
        }

        public void Enter()
        {
        }

        public void Execute()
        {
            if (!_sheep.ReachedPlayer())
            {
                _sheep.FollowPlayer();
            }  
        }

        public void Exit()
        {
            _sheep.SheepManager.DecrementFollowingCount();
        }
    }
}
