using Gameplay.Animals.Sheep;
using UnityEngine;

namespace Gameplay.Animals.States
{
    public class GoingToYardState : IState
    {
        private readonly SheepBase _sheep;
        private readonly Vector3 _yardPosition;
        private readonly float _yardPointThreshold = 1f;

        public GoingToYardState(SheepBase sheep, Vector3 yardPosition)
        {
            _sheep = sheep;
            _yardPosition = yardPosition;
        }

        public void Execute()
        {
            if (Vector3.Distance(_sheep.transform.position, _yardPosition) < _yardPointThreshold)
            {
                _sheep.SheepManager.IncrementSheepInYardCount();
                _sheep.ChangeState(new IdleState());
            }
            else
            {
                _sheep.MoveTowards(_yardPosition);
            }
        }
    }
}
