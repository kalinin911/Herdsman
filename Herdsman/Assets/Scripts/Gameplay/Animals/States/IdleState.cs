using Gameplay.Animals.Sheep;

namespace Gameplay.Animals.States
{
    public class IdleState : INPCState
    {
        private readonly SheepBase _sheep;

        public IdleState(SheepBase sheep)
        {
            _sheep = sheep;
        }

        public void Enter()
        {
        }

        public void Execute()
        {
            //Do nothing 
        }

        public void Exit()
        {
        }
    }
}
