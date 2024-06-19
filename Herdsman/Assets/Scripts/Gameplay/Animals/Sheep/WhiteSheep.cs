using Gameplay.Animals.States;

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
