using Gameplay.Animals.Sheep;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay.Animals.States
{
    public class PatrollingState : INPCState
    {
        private readonly SheepBase _sheep;
        private int _currentWayPointIndex;

        public PatrollingState(SheepBase sheep)
        {
            _sheep = sheep;
        }

        public void Enter()
        {
            Debug.WriteLine("Entering patrolling state");
            //_sheep.SetNextWaypoint();
        }

        public void Execute()
        {
            if (_sheep != null)
            {
                //_sheep.SetNextWaypoint();
            }
            else
            {
                //_sheep.MoveToWaypoint();
            }
        }

        public void Exit()
        {
            Debug.WriteLine("Exiting patrolling state");
        }
    }
}
