namespace Gameplay.Animals.States
{
    public interface IState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}
