using Gameplay.Animals.States;
using UnityEngine;

namespace Gameplay.Animals.Sheep
{
    public class WhiteSheep : SheepBase
    {
        protected override void Start()
        {
            base.Start();
            ChangeState(new PatrollingState(this));
        }
    }
}
