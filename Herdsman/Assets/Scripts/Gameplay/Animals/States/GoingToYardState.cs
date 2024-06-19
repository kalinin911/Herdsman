using Gameplay.Animals.Sheep;
using UnityEngine;

namespace Gameplay.Animals.States
{
    public class GoingToYardState : INPCState
    {
        private readonly SheepBase _sheep;
        private readonly Vector3 _yardPosition;

        public GoingToYardState(SheepBase sheep, Vector3 yardPosition)
        {
            _sheep = sheep;
            _yardPosition = yardPosition;
        }

        public void Enter()
        {
        }

        public void Execute()
        {
            if (Vector3.Distance(_sheep.transform.position, _yardPosition) < 0.1f)
            {
                _sheep.SheepManager.IncrementSheepInYardCount();
                _sheep.ChangeState(new IdleState(_sheep));
            }
            else
            {
                _sheep.MoveTowards(_yardPosition);
            }
        }

        public void Exit()
        {
        }
    }
}
